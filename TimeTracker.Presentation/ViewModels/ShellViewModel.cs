using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class ShellViewModel : ObservableObject
{
    private AppContextStore _appContextStore;

    public ShellViewModel(AppContextStore appContextStore)
    {
        _appContextStore = appContextStore;
    }

    public AppContextStore AppContextStore
    {
        get => _appContextStore;
        private set => SetProperty(ref _appContextStore, value);
    }
}