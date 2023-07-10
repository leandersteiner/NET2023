using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public interface IRecordRepository : IRepository<Record>
{
    Task<List<Record>> FindAllForUser(User user);
}