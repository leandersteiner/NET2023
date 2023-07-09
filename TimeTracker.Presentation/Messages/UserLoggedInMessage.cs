using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class UserLoggedInMessage : ValueChangedMessage<UserViewModel>
{
    public UserLoggedInMessage(UserViewModel value) : base(value)
    {
    }
}