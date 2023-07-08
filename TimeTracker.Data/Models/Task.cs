using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class Task : BaseModel
{
    private string _title = string.Empty;
    private ICollection<Record> _records = null!;
    private ICollection<Task> _subtasks = null!;
    private User _creator = null!;

    [Required]
    [MinLength(3)]
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public ICollection<Record> Records
    {
        get => _records;
        set => SetProperty(ref _records, value);
    }

    public ICollection<Task> Subtasks
    {
        get => _subtasks;
        set => SetProperty(ref _subtasks, value);
    }

    public User Creator
    {
        get => _creator;
        set => SetProperty(ref _creator, value);
    }
}