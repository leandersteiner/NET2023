using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public class WorkItemRepository : BaseRepository<WorkItem>, IWorkItemRepository
{
    public WorkItemRepository(TimeTrackerContext context) : base(context)
    {
    }

    public Task<List<WorkItem>> FindAllForProject(Project project)
    {
        return _context.WorkItems.Where(w => w.Project.Id == project.Id).ToListAsync();
    }
}