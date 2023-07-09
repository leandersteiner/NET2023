using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class NavigationMessage : ValueChangedMessage<string>
{
    public NavigationMessage(string value) : base(value)
    {
    }
}