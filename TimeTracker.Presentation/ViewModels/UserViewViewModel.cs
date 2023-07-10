using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class UserViewViewModel : ObservableObject
{
    private UserViewModel _selectedUser;
    private readonly IUserRepository _userRepository;

    public UserViewViewModel(IUserRepository userRepository, AppContextStore appContextStore)
    {
        _userRepository = userRepository;
        var user = appContextStore.SelectedUser!;
        SelectedUser = new UserViewModel(user);
        UpdateUserCommand = new RelayCommand(UpdateUserExecute, CanUpdate);
        Username = user.Username;
        Email = user.Email;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }

    public UserViewModel SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    private string _username;
    private string _email;
    private string _firstName;

    private string _lastName;

    public string Username
    {
        get => _username;
        set
        {
            if (SetProperty(ref _username, value))
            {
                UpdateUserCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(Username));
            }
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                UpdateUserCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(Email));
            }
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (SetProperty(ref _firstName, value))
            {
                UpdateUserCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (SetProperty(ref _lastName, value))
            {
                UpdateUserCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(LastName));
            }
        }
    }

    public RelayCommand UpdateUserCommand { get; }

    private bool CanUpdate() => !string.IsNullOrEmpty(Username) &&
                                !string.IsNullOrEmpty(Email) &&
                                !string.IsNullOrEmpty(FirstName) &&
                                !string.IsNullOrEmpty(LastName);

    private async void UpdateUserExecute()
    {
        var user = SelectedUser.User;
        user.Username = Username;
        user.Email = Email;
        user.FirstName = FirstName;
        user.LastName = LastName;
        await _userRepository.UpdateAsync(user);
    }
}