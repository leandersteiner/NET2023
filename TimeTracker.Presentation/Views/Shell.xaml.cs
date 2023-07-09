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

        //ContentFrame.Navigate(new UserSelectionView());
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

    private void BackToOrganisationSelectionButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}