using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(TimeTrackerContext context) : base(context)
    {
    }

    public Task<List<Project>> FindAllForUser(User user)
    {
        return _context.Projects.Where(p => p.Creator.Id == user.Id).ToListAsync();
    }

    public Task<List<Project>> FindAllForOrganisation(Organisation organisation)
    {
        return _context.Projects.Where(p => p.Organisation.Id == organisation.Id).ToListAsync();
    }
}