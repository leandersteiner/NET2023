using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TimeTracker.Core.Services;
using TimeTracker.Presentation.Messages;

namespace TimeTracker.Presentation.ViewModels;

public class LoginControlViewModelBase : ViewModelBase
{
    private readonly UserService _userService;

    public LoginControlViewModelBase(UserService userService)
    {
        _userService = userService;
        LoginCommand = new RelayCommand(Login, CanLogin);
    }

    private string _email;
    private string _password;

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                LoginCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(Email));
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                LoginCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    public RelayCommand LoginCommand { get; }

    private bool CanLogin() => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

    private async void Login()
    {
        var user = await _userService.Login(Email, Password);
        if (user is not null)
        {
            var userViewModel = new UserViewModel(user);
            WeakReferenceMessenger.Default.Send(new UserLoggedInMessage(userViewModel));
        }

        Debug.WriteLine("wrong data");
    }
}