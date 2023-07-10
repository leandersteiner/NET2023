using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using TimeTracker.Data.Models;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class ProjectSelectionViewModel : ViewModelBase
{
    private ProjectViewModel? _doubleClickedProject;
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly AppContextStore _appContextStore;

    public ProjectSelectionViewModel(ProjectListViewModel projectListViewModel,
        IDialogCoordinator dialogCoordinator, AppContextStore appContextStore)
    {
        _dialogCoordinator = dialogCoordinator;
        _appContextStore = appContextStore;
        ProjectListViewModel = projectListViewModel;
        ProjectsView = new ListCollectionView(ProjectListViewModel.Projects);
        ProjectsView.CurrentChanged += (_, _) => OnPropertyChanged(nameof(SelectedProject));
    }

    public RelayCommand AddProjectCommand => new(AddProjectExecute);
    public RelayCommand DeleteProjectCommand => new(DeleteProjectExecute);
    public RelayCommand EditProjectCommand => new(EditProjectExecute);

    public ProjectViewModel? DoubleClickedProject
    {
        get => _doubleClickedProject;
        set => SetProperty(ref _doubleClickedProject, value);
    }

    public ListCollectionView ProjectsView { get; }

    public ProjectViewModel? SelectedProject => ProjectsView.CurrentItem as ProjectViewModel;

    private ProjectListViewModel ProjectListViewModel { get; }

    private async void AddProjectExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Add a new Project",
            "Project Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;

        var newProject = new Project
        {
            Name = result,
            Creator = _appContextStore.SelectedUser!,
            Organisation = _appContextStore.SelectedOrganisation!
        };
        await ProjectListViewModel.AddProjectAsync(new ProjectViewModel(newProject));
    }

    private async void DeleteProjectExecute()
    {
        if (SelectedProject != null) await ProjectListViewModel.DeleteProjectAsync(SelectedProject);
    }

    private async void EditProjectExecute()
    {
        var result = await _dialogCoordinator.ShowInputAsync(this, "Edit Project",
            "Project Name (2-32 Characters)",
            new MetroDialogSettings
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateHide = false,
                AnimateShow = false,
                DefaultButtonFocus = MessageDialogResult.Affirmative,
                DefaultText = SelectedProject?.Project.Name
            });

        if (result == null || result.Length <= 2 || result.Length >= 32) return;
        SelectedProject!.Project.Name = result;
        await ProjectListViewModel.UpdateProjectAsync(SelectedProject);
    }
}