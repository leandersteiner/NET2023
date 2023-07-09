using TimeTracker.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeTracker.Data.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindByEmail(string email);
}