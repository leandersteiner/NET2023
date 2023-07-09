using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.Stores;

public class AppContextStore : ObservableObject
{
    private User? _loggedInUser;
    private bool _isLoggedIn;

    private Organisation? _selectedOrganisation;
    private Project? _selectedProject;

    public AppContextStore()
    {
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
}