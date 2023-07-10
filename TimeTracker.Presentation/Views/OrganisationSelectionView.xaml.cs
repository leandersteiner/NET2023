using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class OrganisationSelectionView
{
    private readonly OrganisationSelectionViewModel? _organisationSelectionViewModel;

    public OrganisationSelectionView()
    {
        InitializeComponent();

        _organisationSelectionViewModel = App.Current.Services.GetService<OrganisationSelectionViewModel>();
        DataContext = _organisationSelectionViewModel;
    }

    private void OrganisationSelection_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_organisationSelectionViewModel?.SelectedOrganisation != null)
        {
            Debug.WriteLine("Sent: " + _organisationSelectionViewModel.SelectedOrganisation.Organisation?.Id);
            WeakReferenceMessenger.Default.Send(
                new SelectedOrganisationMessage(_organisationSelectionViewModel.SelectedOrganisation));
        }

        NavigationService?.Navigate(new ProjectSelectionView());
    }

    private void EventSetter_OnHandler(object sender, MouseEventArgs e)
    {
        ((ListBoxItem) sender).IsSelected = true;
    }
}