using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(TimeTrackerContext context) : base(context)
    {
    }

    public Task<User?> FindByEmail(string email)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }
}