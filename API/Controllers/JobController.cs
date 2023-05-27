using API.Cases;
using API.Exceptions;
using API.Repositories.Interfaces;
using API.Requests;
using API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly GetAllJobsCase getAllJobsCase;
        private readonly GetJobByIdCase getJobByIdCase;
        private readonly CreateJobCase createJobCase;

        public JobController(IJobRepository jobRepository)
        {
            getAllJobsCase = new GetAllJobsCase(jobRepository);
            getJobByIdCase = new GetJobByIdCase(jobRepository);
            createJobCase = new CreateJobCase(jobRepository);
        }

        [HttpGet("All/:search")]
        [ProducesResponseType(typeof(IEnumerable<ResponseAllJob>), 200)]
        public IActionResult GetAll(string? search)
        {
            IEnumerable<ResponseAllJob> response = getAllJobsCase.Execute(search);
            return Ok(response);
        }

        [HttpGet("ById/{id}")]
        [ProducesResponseType(typeof(ResponseInfoJob), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            try
            {
                ResponseInfoJob response = getJobByIdCase.Execute(id);
                return Ok(response);
            }
            catch (JobNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult Post(RequestCreateJob request)
        {
            createJobCase.Execute(request);
            return NoContent();
        }
    }
}