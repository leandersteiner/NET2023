using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class ShellViewModel : ObservableObject
{
    private SelectedUserStore _selectedUserStore;

    public ShellViewModel(SelectedUserStore selectedUserStore)
    {
        _selectedUserStore = selectedUserStore;
    }

    public SelectedUserStore SelectedUserStore
    {
        get => _selectedUserStore;
        private set => SetProperty(ref _selectedUserStore, value);
    }
}