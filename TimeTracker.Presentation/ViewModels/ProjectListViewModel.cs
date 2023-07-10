using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class ProjectListViewModel : ViewModelBase
{
    private readonly IProjectRepository _projectRepository;
    private ObservableCollection<ProjectViewModel> _projects;
    private readonly AppContextStore _appContextStore;

    public ProjectListViewModel(IProjectRepository projectRepository, AppContextStore appContextStore)
    {
        _projectRepository = projectRepository;
        _appContextStore = appContextStore;
        Task.Run(LoadProjectsAsync).Wait();
    }

    public ObservableCollection<ProjectViewModel> Projects
    {
        get => _projects;
        set => SetProperty(ref _projects, value);
    }

    public async Task DeleteProjectAsync(ProjectViewModel project)
    {
        Projects.Remove(project);

        await _projectRepository.DeleteAsync(project.Project);
    }

    public async Task UpdateProjectAsync(ProjectViewModel project)
    {
        int index = Projects.IndexOf(project);
        if (index >= 0)
        {
            Projects.RemoveAt(index);
            Projects.Add(project);

            await _projectRepository.UpdateAsync(project.Project);
        }
        else
        {
            throw new IndexOutOfRangeException("Project was not found!");
        }
    }

    public async Task AddProjectAsync(ProjectViewModel project)
    {
        Projects.Add(project);

        await _projectRepository.AddAsync(project.Project);
    }

    private async Task LoadProjectsAsync()
    {
        Projects = new ObservableCollection<ProjectViewModel>();
        Debug.WriteLine(_appContextStore.SelectedOrganisation!.Id);
        var projects = await _projectRepository.FindAllForOrganisation(_appContextStore.SelectedOrganisation!);
        projects.ForEach(o => Projects.Add(new ProjectViewModel(o)));
    }
}