using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.Controls;
using TimeTracker.Presentation.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class ProjectSelectionView
{
    private readonly ProjectSelectionViewModel? _projectSelectionViewModel;

    public ProjectSelectionView()
    {
        InitializeComponent();

        _projectSelectionViewModel = App.Current.Services.GetService<ProjectSelectionViewModel>();
        DataContext = _projectSelectionViewModel;
    }

    private void ProjectSelection_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_projectSelectionViewModel?.SelectedProject != null)
        {
            Debug.WriteLine("Sent: " + _projectSelectionViewModel.SelectedProject.Project?.Id);
            WeakReferenceMessenger.Default.Send(
                new SelectedProjectMessage(_projectSelectionViewModel.SelectedProject));
        }

        NavigationService?.Navigate(new TimeRecorder());
    }

    private void EventSetter_OnHandler(object sender, MouseEventArgs e)
    {
        ((ListBoxItem) sender).IsSelected = true;
    }
}