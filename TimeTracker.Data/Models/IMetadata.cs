namespace TimeTracker.Data.Models;

public interface IMetadata
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}