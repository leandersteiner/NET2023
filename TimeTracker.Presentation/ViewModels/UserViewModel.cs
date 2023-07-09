using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class UserViewModel : ObservableObject
{
    public UserViewModel(User user)
    {
        User = user;
    }

    public User User { get; }
}