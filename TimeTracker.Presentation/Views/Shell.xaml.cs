using System.Windows;
using Microsoft.Extensions.DependencyInjection;
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
        ContentFrame.Navigate(new UserView());
    }

    private void ProjectsButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new ProjectSelectionView());
    }

    private void TasksButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new WorkItemSelectionView());
    }

    private void RecordsButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new RecordedTimesView());
    }

    private void OrganisationsButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new OrganisationSelectionView());
    }

    private void BackToUserSelectionButton_OnClick(object sender, RoutedEventArgs e)
    {
        ContentFrame.Navigate(new UserSelectionView());
    }
}