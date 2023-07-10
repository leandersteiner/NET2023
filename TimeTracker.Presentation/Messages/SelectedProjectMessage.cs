using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class SelectedProjectMessage : ValueChangedMessage<ProjectViewModel?>
{
    public SelectedProjectMessage(ProjectViewModel? value) : base(value)
    {
    }
}