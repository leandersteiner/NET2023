using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Controls;

public partial class LoginControl : UserControl
{
    private readonly LoginControlViewModelBase? _loginControlViewModel;

    public LoginControl()
    {
        InitializeComponent();

        _loginControlViewModel = App.Current.Services.GetService<LoginControlViewModelBase>();
        DataContext = _loginControlViewModel;
    }
}