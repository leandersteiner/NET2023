using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeTracker.Core.Services;

namespace TimeTracker.Presentation.ViewModels;

public class SignupControlViewModel : ViewModel
{
    private readonly UserService _userService;

    public SignupControlViewModel(UserService userService)
    {
        _userService = userService;
        SignupCommand = new RelayCommand(Signup, CanSignup);
    }

    private string _firstName;
    private string _lastName;
    private string _email;
    private string _password;

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!SetProperty(ref _firstName, value)) return;
            SignupCommand.NotifyCanExecuteChanged();
            OnPropertyChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (!SetProperty(ref _lastName, value)) return;
            SignupCommand.NotifyCanExecuteChanged();
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (!SetProperty(ref _email, value)) return;
            SignupCommand.NotifyCanExecuteChanged();
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (!SetProperty(ref _password, value)) return;
            SignupCommand.NotifyCanExecuteChanged();
            OnPropertyChanged();
        }
    }

    public RelayCommand SignupCommand { get; }

    private bool CanSignup() => !string.IsNullOrEmpty(FirstName) &&
                                !string.IsNullOrEmpty(LastName) &&
                                !string.IsNullOrEmpty(Email) &&
                                !string.IsNullOrEmpty(Password);

    private async void Signup()
    {
        var user = await this._userService.Signup(FirstName, LastName, Email, Password);
        Debug.WriteLine(user.Id);
    }
}