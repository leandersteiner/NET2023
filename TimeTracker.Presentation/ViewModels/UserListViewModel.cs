using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;

namespace TimeTracker.Presentation.ViewModels;

public class UserListViewModel : ViewModelBase
{
    private readonly IRepository<User> _userRepository;
    private ObservableCollection<UserViewModel> _users;

    public UserListViewModel(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
        Task.Run(LoadUsersAsync).Wait();
    }

    public ObservableCollection<UserViewModel> Users
    {
        get => _users;
        set => SetProperty(ref _users, value);
    }

    public async Task DeleteUserAsync(UserViewModel user)
    {
        Users.Remove(user);

        await _userRepository.DeleteAsync(user.User);
    }

    public async Task UpdateUserAsync(UserViewModel user)
    {
        int index = Users.IndexOf(user);
        if (index >= 0)
        {
            Users.RemoveAt(index);
            Users.Add(user);

            await _userRepository.UpdateAsync(user.User);
        }
        else
        {
            throw new IndexOutOfRangeException("User was not found!");
        }
    }

    public async Task AddUserAsync(UserViewModel user)
    {
        Users.Add(user);

        await _userRepository.AddAsync(user.User);
    }

    private async Task LoadUsersAsync()
    {
        Users = new ObservableCollection<UserViewModel>();
        var users = await _userRepository.FindAllAsync();
        users.ForEach(u => Users.Add(new UserViewModel(u)));
    }
}