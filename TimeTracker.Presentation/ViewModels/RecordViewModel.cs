using TimeTracker.Data.Models;

namespace TimeTracker.Presentation.ViewModels;

public class RecordViewModel : ViewModelBase
{
    public RecordViewModel(Record record)
    {
        Record = record;
    }

    public Record Record { get; }
}