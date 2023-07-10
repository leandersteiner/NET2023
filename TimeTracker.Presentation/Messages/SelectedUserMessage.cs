using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class SelectedUserMessage : ValueChangedMessage<UserViewModel?>
{
    public SelectedUserMessage(UserViewModel? value) : base(value)
    {
    }
}