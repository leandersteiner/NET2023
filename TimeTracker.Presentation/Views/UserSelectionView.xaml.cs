using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class UserSelectionView
{
    private readonly UserSelectionViewModel? _userSelectionViewModel;

    public UserSelectionView()
    {
        InitializeComponent();

        _userSelectionViewModel = App.Current.Services.GetService<UserSelectionViewModel>();
        DataContext = _userSelectionViewModel;
    }

    private void UserSelection_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_userSelectionViewModel?.SelectedUser != null)
        {
            Debug.WriteLine("Sent: " + _userSelectionViewModel.SelectedUser.User?.Id);
            WeakReferenceMessenger.Default.Send(new SelectedUserMessage(_userSelectionViewModel.SelectedUser));
        }

        NavigationService?.Navigate(new OrganisationSelectionView());
    }

    private void EventSetter_OnHandler(object sender, MouseEventArgs e)
    {
        ((ListBoxItem) sender).IsSelected = true;
    }
}