using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Controls;

public partial class SignupControl : UserControl
{
    private readonly SignupControlViewModelBase? _signupControlViewModel;

    public SignupControl()
    {
        InitializeComponent();

        _signupControlViewModel = App.Current.Services.GetService<SignupControlViewModelBase>();
        DataContext = _signupControlViewModel;
    }
}