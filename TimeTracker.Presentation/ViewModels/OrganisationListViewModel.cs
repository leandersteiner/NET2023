using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class OrganisationListViewModel : ViewModelBase
{
    private readonly IOrganisationRepository _organisationRepository;
    private ObservableCollection<OrganisationViewModel> _organisations;
    private readonly AppContextStore _appContextStore;

    public OrganisationListViewModel(IOrganisationRepository organisationRepository, AppContextStore appContextStore)
    {
        _organisationRepository = organisationRepository;
        _appContextStore = appContextStore;
        Task.Run(LoadOrganisationsAsync).Wait();
    }

    public ObservableCollection<OrganisationViewModel> Organisations
    {
        get => _organisations;
        set => SetProperty(ref _organisations, value);
    }

    public async Task DeleteOrganisationAsync(OrganisationViewModel organisation)
    {
        Organisations.Remove(organisation);

        await _organisationRepository.DeleteAsync(organisation.Organisation);
    }

    public async Task UpdateOrganisationAsync(OrganisationViewModel organisation)
    {
        int index = Organisations.IndexOf(organisation);
        if (index >= 0)
        {
            Organisations.RemoveAt(index);
            Organisations.Add(organisation);

            await _organisationRepository.UpdateAsync(organisation.Organisation);
        }
        else
        {
            throw new IndexOutOfRangeException("Organisation was not found!");
        }
    }

    public async Task AddOrganisationAsync(OrganisationViewModel organisation)
    {
        Organisations.Add(organisation);

        await _organisationRepository.AddAsync(organisation.Organisation);
    }

    private async Task LoadOrganisationsAsync()
    {
        Organisations = new ObservableCollection<OrganisationViewModel>();
        var organisations = await _organisationRepository.FindAllForUser(_appContextStore.SelectedUser!);
        organisations.ForEach(o => Organisations.Add(new OrganisationViewModel(o)));
    }
}