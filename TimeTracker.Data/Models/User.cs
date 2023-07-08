using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Models;

public class User : BaseModel
{
    private string _email = string.Empty;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _password = string.Empty;

    [Required]
    [EmailAddress]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    [Required]
    [MinLength(3)]
    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    [Required]
    [MinLength(3)]
    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    [Required]
    [MinLength(8)]
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }
}