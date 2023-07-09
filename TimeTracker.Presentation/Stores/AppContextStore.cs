using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Messages;

namespace TimeTracker.Presentation.Stores;

public class AppContextStore : ObservableRecipient, IRecipient<UserLoggedInMessage>
{
    private User? _loggedInUser;
    private bool _isLoggedIn;

    private Organisation? _selectedOrganisation;
    private Project? _selectedProject;

    public AppContextStore()
    {
        WeakReferenceMessenger.Default.Register(this);
        LoggedInUser = null;
        IsLoggedIn = false;
    }

    public User? LoggedInUser
    {
        get => _loggedInUser;
        set => SetProperty(ref _loggedInUser, value);
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

    public void Receive(UserLoggedInMessage message)
    {
        Debug.WriteLine("Received");
        LoggedInUser = message.Value.User;
        if (LoggedInUser == null)
        {
            IsLoggedIn = false;
        }

        IsLoggedIn = true;
    }
}