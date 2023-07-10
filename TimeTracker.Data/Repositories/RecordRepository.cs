using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public class RecordRepository : BaseRepository<Record>, IRecordRepository
{
    public RecordRepository(TimeTrackerContext context) : base(context)
    {
    }

    public Task<List<Record>> FindAllForProject(Project project)
    {
        return _context.Records.Where(r => r.Project.Id == project.Id).ToListAsync();
    }
}