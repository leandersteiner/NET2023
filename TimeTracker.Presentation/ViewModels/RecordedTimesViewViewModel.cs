using System.Diagnostics;
using System.Windows.Data;

namespace TimeTracker.Presentation.ViewModels;

public class RecordedTimesViewViewModel : ViewModelBase
{
    public RecordedTimesViewViewModel(RecordListViewModel recordListViewModel)
    {
        RecordListViewModel = recordListViewModel;
        RecordsView = new ListCollectionView(RecordListViewModel.Records);
    }

    public ListCollectionView RecordsView { get; }

    private RecordListViewModel RecordListViewModel { get; }
}