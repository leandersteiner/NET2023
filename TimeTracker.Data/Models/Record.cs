using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class Record : BaseModel
{
    private DateTime _start;
    private DateTime _end;
    private User _creator = null!;

    [Required]
    public DateTime Start
    {
        get => _start;
        set => SetProperty(ref _start, value);
    }

    [Required]
    public DateTime End
    {
        get => _end;
        set => SetProperty(ref _end, value);
    }

    public User Creator
    {
        get => _creator;
        set => SetProperty(ref _creator, value);
    }
}