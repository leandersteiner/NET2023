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
    private readonly OrganisationSelectionViewModel? _OrganisationSelectionViewModel;

    public OrganisationSelectionView()
    {
        InitializeComponent();

        _OrganisationSelectionViewModel = App.Current.Services.GetService<OrganisationSelectionViewModel>();
        DataContext = _OrganisationSelectionViewModel;
    }

    private void OrganisationSelection_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_OrganisationSelectionViewModel?.SelectedOrganisation != null)
        {
            Debug.WriteLine("Sent: " + _OrganisationSelectionViewModel.SelectedOrganisation.Organisation?.Id);
            WeakReferenceMessenger.Default.Send(
                new SelectedOrganisationMessage(_OrganisationSelectionViewModel.SelectedOrganisation));
        }

        NavigationService?.Navigate(new HomeView());
    }

    private void EventSetter_OnHandler(object sender, MouseEventArgs e)
    {
        ((ListBoxItem) sender).IsSelected = true;
    }
}