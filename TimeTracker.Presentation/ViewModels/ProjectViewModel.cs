using CommunityToolkit.Mvvm.ComponentModel;
using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class ProjectViewModel : ViewModelBase
{
    public ProjectViewModel(Project project)
    {
        Project = project;
    }

    public Project Project { get; }
}