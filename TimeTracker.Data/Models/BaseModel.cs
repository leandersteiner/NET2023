using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeTracker.Data.Models;

public class BaseModel : ObservableValidator, IMetadata
{
    private int _id;

    private DateTime _createdAt;
    private DateTime _updatedAt;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set => SetProperty(ref _createdAt, value);
    }

    public DateTime UpdatedAt
    {
        get => _updatedAt;
        set => SetProperty(ref _updatedAt, value);
    }
}