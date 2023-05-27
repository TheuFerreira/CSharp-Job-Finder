using API.Entities;
using API.Exceptions;
using API.Repositories.Interfaces;
using API.Responses;

namespace API.Cases
{
    public class GetJobByIdCase
    {
        private readonly IJobRepository jobRepository;

        public GetJobByIdCase(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public ResponseInfoJob Execute(int id)
        {
            Job job = jobRepository.GetById(id) ?? throw new JobNotFoundException();

            ResponseInfoJob response = new()
            {
                Title = job.Title,
                Company = job.Company,
                Description = job.Description,
                Email = job.Email,
                Salary = job.Salary,
            };

            return response;
        }
    }
}
