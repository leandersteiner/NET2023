using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class UserView
{
    private readonly UserViewViewModel? _userViewViewModel;

    public UserView()
    {
        InitializeComponent();

        _userViewViewModel = App.Current.Services.GetService<UserViewViewModel>();
        DataContext = _userViewViewModel;
    }
}