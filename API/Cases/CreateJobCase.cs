using API.Entities;
using API.Repositories.Interfaces;
using API.Requests;

namespace API.Cases
{
    public class CreateJobCase
    {
        private readonly IJobRepository jobRepository;

        public CreateJobCase(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public void Execute(RequestCreateJob request)
        {
            Job job = new()
            {
                Title = request.Title,
                Company = request.Company,
                Description = request.Description,
                Email = request.Email,
                Salary = request.Salary,
                CreatedAt = DateTime.UtcNow,
            };

            jobRepository.Save(job);
        }
    }
}
