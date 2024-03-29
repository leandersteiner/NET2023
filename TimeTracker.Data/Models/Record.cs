﻿using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class Record : BaseModel
{
    private DateTime _start;
    private DateTime _end;
    private TimeSpan _duration;
    private User _creator = null!;
    private Project _project = null!;
    private WorkItem _workItem = null!;

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

    [Required]
    public TimeSpan Duration
    {
        get => _duration;
        set => SetProperty(ref _duration, value);
    }

    public User Creator
    {
        get => _creator;
        set => SetProperty(ref _creator, value);
    }

    public Project Project
    {
        get => _project;
        set => SetProperty(ref _project, value);
    }

    public WorkItem WorkItem
    {
        get => _workItem;
        set => SetProperty(ref _workItem, value);
    }
}