using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.Presentation.Messages;
using TimeTracker.Presentation.ViewModels;

namespace TimeTracker.Presentation.Views;

public partial class Shell
{
    public Shell()
    {
        InitializeComponent();

        var shellViewModel = App.Current.Services.GetService<ShellViewModel>();
        DataContext = shellViewModel;

        ContentFrame.Navigate(new UserSelectionView());
    }

    private void UserButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ProjectsButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void TasksButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RecordsButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void OrganisationsButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new OrganisationSelectionView());
    }

    private void BackToUserSelectionButton_OnClick(object sender, RoutedEventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new SelectedUserMessage(null));
        ContentFrame.Navigate(new UserSelectionView());
    }
}