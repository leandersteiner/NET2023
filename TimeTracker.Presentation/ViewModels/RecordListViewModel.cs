using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class RecordListViewModel : ViewModelBase
{
    private readonly IRecordRepository _recordRepository;
    private ObservableCollection<RecordViewModel> _records;
    private AppContextStore _appContextStore;

    public RecordListViewModel(IRecordRepository recordRepository, AppContextStore appContextStore)
    {
        _appContextStore = appContextStore;
        _recordRepository = recordRepository;
        Task.Run(LoadRecordsAsync).Wait();
    }

    public ObservableCollection<RecordViewModel> Records
    {
        get => _records;
        set => SetProperty(ref _records, value);
    }

    public async Task DeleteRecordAsync(RecordViewModel record)
    {
        Records.Remove(record);

        await _recordRepository.DeleteAsync(record.Record);
    }

    public async Task UpdateRecordAsync(RecordViewModel record)
    {
        int index = Records.IndexOf(record);
        if (index >= 0)
        {
            Records.RemoveAt(index);
            Records.Add(record);

            await _recordRepository.UpdateAsync(record.Record);
        }
        else
        {
            throw new IndexOutOfRangeException("Record was not found!");
        }
    }

    public async Task AddRecordAsync(RecordViewModel record)
    {
        Records.Add(record);

        await _recordRepository.AddAsync(record.Record);
    }

    private async Task LoadRecordsAsync()
    {
        Records = new ObservableCollection<RecordViewModel>();
        var records = await _recordRepository.FindAllForUser(_appContextStore.SelectedUser!);
        records.ForEach(r => Records.Add(new RecordViewModel(r)));
    }
}