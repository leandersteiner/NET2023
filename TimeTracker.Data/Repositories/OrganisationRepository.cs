using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public class OrganisationRepository : BaseRepository<Organisation>, IOrganisationRepository
{
    public OrganisationRepository(TimeTrackerContext context) : base(context)
    {
    }

    public Task<List<Organisation>> FindAllForUser(User user)
    {
        return _context.Organisations.Where(o => o.Creator.Id == user.Id).ToListAsync();
    }
}