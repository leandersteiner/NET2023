using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;

namespace TimeTracker.Core.Services;

public class UserService
{
    private IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
}