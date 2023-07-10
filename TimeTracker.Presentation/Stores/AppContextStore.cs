using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Messages;

namespace TimeTracker.Presentation.Stores;

public class AppContextStore : ObservableRecipient, IRecipient<SelectedUserMessage>,
    IRecipient<SelectedOrganisationMessage>, IRecipient<SelectedProjectMessage>, IRecipient<SelectedWorkItemMessage>
{
    private User? _selectedUser;
    private bool _userSelected;

    private Organisation? _selectedOrganisation;
    private Project? _selectedProject;
    private WorkItem? _selectedWorkItem;

    public AppContextStore()
    {
        WeakReferenceMessenger.Default.RegisterAll(this);
        SelectedUser = null;
        UserSelected = false;
    }

    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public bool UserSelected
    {
        get => _userSelected;
        set => SetProperty(ref _userSelected, value);
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

    public WorkItem? SelectedWorkItem
    {
        get => _selectedWorkItem;
        set => SetProperty(ref _selectedWorkItem, value);
    }

    public void Receive(SelectedUserMessage message)
    {
        if (message.Value is null)
        {
            SelectedUser = null;
            UserSelected = false;
            return;
        }

        SelectedUser = message.Value.User;
        if (SelectedUser == null)
        {
            UserSelected = false;
            return;
        }

        UserSelected = true;
    }

    public void Receive(SelectedOrganisationMessage message)
    {
        if (message.Value is null)
        {
            SelectedOrganisation = null;
            return;
        }

        SelectedOrganisation = message.Value.Organisation;
    }

    public void Receive(SelectedProjectMessage message)
    {
        if (message.Value is null)
        {
            SelectedProject = null;
            return;
        }

        SelectedProject = message.Value.Project;
    }

    public void Receive(SelectedWorkItemMessage message)
    {
        if (message.Value is null)
        {
            SelectedWorkItem = null;
            return;
        }

        SelectedWorkItem = message.Value.WorkItem;
    }
}