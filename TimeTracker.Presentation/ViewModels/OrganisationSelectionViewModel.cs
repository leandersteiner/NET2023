using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class OrganisationSelectionViewModel : ViewModelBase
{
    private OrganisationViewModel? _doubleClickedOrganisation;
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly AppContextStore _appContextStore;

    public OrganisationSelectionViewModel(OrganisationListViewModel organisationListViewModel,
        IDialogCoordinator dialogCoordinator, AppContextStore appContextStore)
    {
        _dialogCoordinator = dialogCoordinator;
        _appContextStore = appContextStore;
        OrganisationListViewModel = organisationListViewModel;
        OrganisationsView = new ListCollectionView(OrganisationListViewModel.Organisations);
        OrganisationsView.CurrentChanged += (_, _) => OnPropertyChanged(nameof(SelectedOrganisation));
    }

    public RelayCommand AddOrganisationCommand => new(AddOrganisationExecute);
    public RelayCommand DeleteOrganisationCommand => new(DeleteOrganisationExecute);
    public RelayCommand EditOrganisationCommand => new(EditOrganisationExecute);

    public OrganisationViewModel? DoubleClickedOrganisation
    {
        get => _doubleClickedOrganisation;
        set => SetProperty(ref _doubleClickedOrganisation, value);
    }

    public ListCollectionView OrganisationsView { get; }

    public OrganisationViewModel? SelectedOrganisation => OrganisationsView.CurrentItem as OrganisationViewModel;

    private OrganisationListViewModel OrganisationListViewModel { get; }

    private async void AddOrganisationExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Add a new Organisation",
            "Organisation Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;

        var newOrganisation = new Organisation {Name = result, Creator = _appContextStore.SelectedUser!};
        await OrganisationListViewModel.AddOrganisationAsync(new OrganisationViewModel(newOrganisation));
    }

    private async void DeleteOrganisationExecute()
    {
        if (SelectedOrganisation != null) await OrganisationListViewModel.DeleteOrganisationAsync(SelectedOrganisation);
    }

    private async void EditOrganisationExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Edit Organisation",
            "Organisation Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative,
                DefaultText = SelectedOrganisation?.Organisation.Name
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;
        SelectedOrganisation!.Organisation.Name = result;
        await OrganisationListViewModel.UpdateOrganisationAsync(SelectedOrganisation);
    }
}