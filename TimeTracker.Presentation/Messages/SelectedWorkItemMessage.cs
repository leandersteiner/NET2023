using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class SelectedWorkItemMessage : ValueChangedMessage<WorkItemViewModel?>
{
    public SelectedWorkItemMessage(WorkItemViewModel? value) : base(value)
    {
    }
}