using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class WorkItemSelectionViewModel : ViewModelBase
{
    private WorkItemViewModel? _doubleClickedWorkItem;
    private readonly IDialogCoordinator _dialogCoordinator;

    public WorkItemSelectionViewModel(WorkItemListViewModel workItemListViewModel, IDialogCoordinator dialogCoordinator)
    {
        _dialogCoordinator = dialogCoordinator;
        WorkItemListViewModel = workItemListViewModel;
        WorkItemsView = new ListCollectionView(WorkItemListViewModel.WorkItems);
        WorkItemsView.CurrentChanged += (_, _) => OnPropertyChanged(nameof(SelectedWorkItem));
    }

    public RelayCommand AddWorkItemCommand => new(AddWorkItemExecute);
    public RelayCommand DeleteWorkItemCommand => new(DeleteWorkItemExecute);
    public RelayCommand EditWorkItemCommand => new(EditWorkItemExecute);

    public WorkItemViewModel? DoubleClickedWorkItem
    {
        get => _doubleClickedWorkItem;
        set => SetProperty(ref _doubleClickedWorkItem, value);
    }

    public ListCollectionView WorkItemsView { get; }

    public WorkItemViewModel? SelectedWorkItem => WorkItemsView.CurrentItem as WorkItemViewModel;

    private WorkItemListViewModel WorkItemListViewModel { get; }

    private async void AddWorkItemExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Add a new WorkItem",
            "Work Item Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;

        var newWorkItem = new WorkItem {Title = result};
        await WorkItemListViewModel.AddWorkItemAsync(new WorkItemViewModel(newWorkItem));
    }

    private async void DeleteWorkItemExecute()
    {
        if (SelectedWorkItem != null) await WorkItemListViewModel.DeleteWorkItemAsync(SelectedWorkItem);
    }

    private async void EditWorkItemExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Edit WorkItem", "Work Item Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative,
                DefaultText = SelectedWorkItem?.WorkItem.Title
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;
        SelectedWorkItem!.WorkItem.Title = result;
        await WorkItemListViewModel.UpdateWorkItemAsync(SelectedWorkItem);
    }
}