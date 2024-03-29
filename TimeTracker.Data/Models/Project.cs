﻿using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class Project : BaseModel
{
    private string _name = string.Empty;
    private User _creator = null!;
    private Organisation _organisation = null!;

    [Required]
    [MinLength(3)]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public User Creator
    {
        get => _creator;
        set => SetProperty(ref _creator, value);
    }

    public Organisation Organisation
    {
        get => _organisation;
        set => SetProperty(ref _organisation, value);
    }
}