using API.Entities;
using API.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace API.Repositories
{
    public class JobRepository : IJobRepository
    {
        public IDbConnection connection;

        public JobRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Job> GetAll()
        {
            string sql = "SELECT id, title, company, salary, created_at AS CreatedAt FROM jobs ORDER BY created_at DESC";
            IEnumerable<Job> jobs = connection.Query<Job>(sql);
            return jobs;
        }

        public IEnumerable<Job> GetAllWithSearch(string search)
        {
            string sql = $"SELECT id, title, company, salary, created_at AS CreatedAt FROM jobs WHERE title LIKE '%{search}%'";
            IEnumerable<Job> jobs = connection.Query<Job>(sql);
            return jobs;
        }

        public Job? GetById(int id)
        {
            string sql = "SELECT title, description, company, email, salary FROM jobs";
            object data = new { id };

            Job? job = connection.Query<Job>(sql, data).FirstOrDefault();
            return job;
        }

        public int Save(Job job)
        {
            string sql = @"
INSERT INTO jobs (title, description, email, salary, created_at, company) 
VALUES (@title, @description, @email, @salary, @createdAt, @company);
";
            object data = new 
            {
                title = job.Title,
                description = job.Description,
                salary = job.Salary,
                email = job.Email,
                createdAt = job.CreatedAt,
                company = job.Company,
            };

            int res = connection.Execute(sql, data);
            return res;
        }
    }
}
