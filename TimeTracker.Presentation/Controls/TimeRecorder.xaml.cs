using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Controls;

public partial class TimeRecorder : Page
{
    private readonly TimeRecorderViewModel? _timeRecorderViewModel;

    public TimeRecorder()
    {
        InitializeComponent();

        _timeRecorderViewModel = App.Current.Services.GetService<TimeRecorderViewModel>();
        DataContext = _timeRecorderViewModel;
    }
}