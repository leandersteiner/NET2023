using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class OrganisationViewModel : ViewModelBase
{
    public OrganisationViewModel(Organisation org)
    {
        Organisation = org;
    }

    public Organisation Organisation { get; }
}