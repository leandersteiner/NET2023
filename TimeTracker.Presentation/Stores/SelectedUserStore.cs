using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Messages;

namespace TimeTracker.Presentation.Stores;

public class SelectedUserStore : ObservableRecipient, IRecipient<SelectedUserMessage>
{
    private User? _selectedUser;
    private bool _isSelected;

    public SelectedUserStore()
    {
        WeakReferenceMessenger.Default.Register(this);
        SelectedUser = null;
        IsSelected = false;
    }

    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }

    public void Receive(SelectedUserMessage message)
    {
        SelectedUser = message.Value.User;
        if (SelectedUser == null)
        {
            IsSelected = false;
        }

        IsSelected = true;
    }
}