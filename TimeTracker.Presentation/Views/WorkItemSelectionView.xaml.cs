using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.Controls;
using TimeTracker.Presentation.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class WorkItemSelectionView
{
    private readonly WorkItemSelectionViewModel? _workItemSelectionViewModel;

    public WorkItemSelectionView()
    {
        InitializeComponent();

        _workItemSelectionViewModel = App.Current.Services.GetService<WorkItemSelectionViewModel>();
        DataContext = _workItemSelectionViewModel;
    }

    private void WorkItemSelection_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_workItemSelectionViewModel?.SelectedWorkItem != null)
        {
            Debug.WriteLine("Sent: " + _workItemSelectionViewModel.SelectedWorkItem.WorkItem?.Id);
            WeakReferenceMessenger.Default.Send(
                new SelectedWorkItemMessage(_workItemSelectionViewModel.SelectedWorkItem));
        }

        NavigationService?.Navigate(new TimeRecorder());
    }

    private void EventSetter_OnHandler(object sender, MouseEventArgs e)
    {
        ((ListBoxItem) sender).IsSelected = true;
    }
}