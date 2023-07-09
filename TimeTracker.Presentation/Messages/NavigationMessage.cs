using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class NavigationMessage : ValueChangedMessage<ViewModel>
{
    public NavigationMessage(ViewModel value) : base(value)
    {
    }
}