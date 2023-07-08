using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class Organisation : BaseModel
{
    private string _name = string.Empty;
    private ICollection<Project> _projects = null!;
    private User _creator = null!;

    [Required]
    [MinLength(3)]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public ICollection<Project> Projects
    {
        get => _projects;
        set => SetProperty(ref _projects, value);
    }

    public User Creator
    {
        get => _creator;
        set => SetProperty(ref _creator, value);
    }
}