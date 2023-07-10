using CommunityToolkit.Mvvm.Messaging.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Messages;

public class SelectedOrganisationMessage : ValueChangedMessage<OrganisationViewModel?>
{
    public SelectedOrganisationMessage(OrganisationViewModel? value) : base(value)
    {
    }
}