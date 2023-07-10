using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class WorkItemViewModel : ViewModelBase
{
    public WorkItemViewModel(WorkItem workItem)
    {
        WorkItem = workItem;
    }

    public WorkItem WorkItem { get; }
}