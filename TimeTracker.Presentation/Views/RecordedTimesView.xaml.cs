using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class RecordedTimesView : Page
{
    private readonly RecordedTimesViewViewModel? _recordedTimesViewViewModel;

    public RecordedTimesView()
    {
        InitializeComponent();

        _recordedTimesViewViewModel = App.Current.Services.GetService<RecordedTimesViewViewModel>();
        DataContext = _recordedTimesViewViewModel;
    }
}