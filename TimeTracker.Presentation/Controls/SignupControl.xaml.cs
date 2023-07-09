using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Controls;

public partial class SignupControl : UserControl
{
    private readonly SignupControlViewModel? _signupControlViewModel;

    public SignupControl()
    {
        InitializeComponent();

        _signupControlViewModel = App.Current.Services.GetService<SignupControlViewModel>();
        DataContext = _signupControlViewModel;
    }
}