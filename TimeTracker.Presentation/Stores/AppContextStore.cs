using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Messages;

namespace TimeTracker.Presentation.Stores;

public class AppContextStore : ObservableRecipient, IRecipient<SelectedUserMessage>
{
    private User? _selectedUser;
    private bool _isLoggedIn;

    private Organisation? _selectedOrganisation;
    private Project? _selectedProject;

    public AppContextStore()
    {
        WeakReferenceMessenger.Default.Register(this);
        SelectedUser = null;
        IsLoggedIn = false;
    }

    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set => SetProperty(ref _isLoggedIn, value);
    }

    public Organisation? SelectedOrganisation
    {
        get => _selectedOrganisation;
        set => SetProperty(ref _selectedOrganisation, value);
    }

    public Project? SelectedProject
    {
        get => _selectedProject;
        set => SetProperty(ref _selectedProject, value);
    }

    public void Receive(SelectedUserMessage message)
    {
        SelectedUser = message.Value.User;
        if (SelectedUser == null)
        {
            IsLoggedIn = false;
        }

        IsLoggedIn = true;
    }
}