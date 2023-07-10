using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class WorkItemListViewModel : ViewModelBase
{
    private readonly WorkItemRepository _workItemRepository;
    private ObservableCollection<WorkItemViewModel> _workItems;
    private AppContextStore _appContextStore;

    public WorkItemListViewModel(WorkItemRepository workItemRepository, AppContextStore appContextStore)
    {
        _workItemRepository = workItemRepository;
        _appContextStore = appContextStore;
        Task.Run(LoadWorkItemsAsync).Wait();
    }

    public ObservableCollection<WorkItemViewModel> WorkItems
    {
        get => _workItems;
        set => SetProperty(ref _workItems, value);
    }

    public async Task DeleteWorkItemAsync(WorkItemViewModel workItem)
    {
        WorkItems.Remove(workItem);

        await _workItemRepository.DeleteAsync(workItem.WorkItem);
    }

    public async Task UpdateWorkItemAsync(WorkItemViewModel workItem)
    {
        int index = WorkItems.IndexOf(workItem);
        if (index >= 0)
        {
            WorkItems.RemoveAt(index);
            WorkItems.Add(workItem);

            await _workItemRepository.UpdateAsync(workItem.WorkItem);
        }
        else
        {
            throw new IndexOutOfRangeException("WorkItem was not found!");
        }
    }

    public async Task AddWorkItemAsync(WorkItemViewModel workItem)
    {
        WorkItems.Add(workItem);

        await _workItemRepository.AddAsync(workItem.WorkItem);
    }

    private async Task LoadWorkItemsAsync()
    {
        WorkItems = new ObservableCollection<WorkItemViewModel>();
        var workItems = await _workItemRepository.FindAllForProject(_appContextStore.SelectedProject!);
        workItems.ForEach(u => WorkItems.Add(new WorkItemViewModel(u)));
    }
}