using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeTracker.Data.Models;

public class User : BaseModel
{
    private string _username;
    private string _email;
    private string _firstName;
    private string _lastName;
    private string _password;

    [Required]
    [MinLength(2)]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }
}