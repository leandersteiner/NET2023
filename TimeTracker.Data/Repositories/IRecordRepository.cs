using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public interface IRecordRepository : IRepository<Record>
{
    Task<List<Record>> FindAllForProject(Project project);
}