using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;

namespace TimeTracker.Core.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Login(string email, string password)
    {
        var user = await _userRepository.FindByEmail(email);
        if (user is null) return user;
        return user.Password == password ? user : null;
    }

    public async Task<User> Signup(string firstName, string lastName, string email, string password)
    {
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        return await _userRepository.AddAsync(user);
    }
}