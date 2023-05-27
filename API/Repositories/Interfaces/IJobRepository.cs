using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetAll();
        IEnumerable<Job> GetAllWithSearch(string search);
        Job? GetById(int id);
        int Save(Job job);
    }
}
