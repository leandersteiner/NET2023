using TimeTracker.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeTracker.Data.Repositories;

public interface IWorkItemRepository : IRepository<WorkItem>
{
    Task<List<WorkItem>> FindAllForProject(Project project);
}