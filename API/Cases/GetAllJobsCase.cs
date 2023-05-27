using API.Entities;
using API.Repositories.Interfaces;
using API.Responses;

namespace API.Cases
{
    public class GetAllJobsCase
    {
        private readonly IJobRepository jobRepository;

        public GetAllJobsCase(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public IEnumerable<ResponseAllJob> Execute(string? search)
        {
            IEnumerable<Job> jobs;

            if (search == null)
                jobs = jobRepository.GetAll();
            else
                jobs = jobRepository.GetAllWithSearch(search);

            IEnumerable<ResponseAllJob> responses = jobs.Select(x =>
            {
                DateTime lastDayInUTC = DateTime.UtcNow.AddDays(-1);
                bool isNew = lastDayInUTC <= x.CreatedAt;

                return new ResponseAllJob
                {
                    JobId = x.Id,
                    Title = x.Title,
                    Company = x.Company,
                    Salary = x.Salary,
                    IsNew = isNew,
                };
            });

            return responses;
        }
    }
}
