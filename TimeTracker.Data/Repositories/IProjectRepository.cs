using TimeTracker.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeTracker.Data.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<List<Project>> FindAllForOrganisation(Organisation organisation);
}