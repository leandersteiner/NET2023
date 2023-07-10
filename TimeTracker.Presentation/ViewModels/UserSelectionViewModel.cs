using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class UserSelectionViewModel : ViewModelBase
{
    private UserViewModel? _doubleClickedUser;
    private IDialogCoordinator _dialogCoordinator;

    public UserSelectionViewModel(UserListViewModel userListViewModel, IDialogCoordinator dialogCoordinator)
    {
        _dialogCoordinator = dialogCoordinator;
        UserListViewModel = userListViewModel;
        UsersView = new ListCollectionView(UserListViewModel.Users);
        UsersView.CurrentChanged += (_, _) => OnPropertyChanged(nameof(SelectedUser));
    }

    public RelayCommand AddUserCommand => new(AddUserExecute);
    public RelayCommand DeleteUserCommand => new(DeleteUserExecute);
    public RelayCommand EditUserCommand => new(EditUserExecute);

    public UserViewModel? DoubleClickedUser
    {
        get => _doubleClickedUser;
        set => SetProperty(ref _doubleClickedUser, value);
    }

    public ListCollectionView UsersView { get; }

    public UserViewModel? SelectedUser => UsersView.CurrentItem as UserViewModel;

    public UserListViewModel UserListViewModel { get; }

    private async void AddUserExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Add a new User", "Username (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;

        var newUser = new User {Username = result};
        await UserListViewModel.AddUserAsync(new UserViewModel(newUser));
    }

    private async void DeleteUserExecute()
    {
        await UserListViewModel.DeleteUserAsync(SelectedUser);
    }

    private async void EditUserExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Edit User", "Username (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative,
                DefaultText = SelectedUser.User.Username
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;
        SelectedUser.User.Username = result;
        await UserListViewModel.UpdateUserAsync(SelectedUser);
    }
}