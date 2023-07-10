using TimeTracker.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeTracker.Data.Repositories;

public interface IOrganisationRepository : IRepository<Organisation>
{
    Task<List<Organisation>> FindAllForUser(User user);
}