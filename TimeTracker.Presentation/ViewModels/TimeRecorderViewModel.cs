using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using TimeTracker.Data.Models;
using TimeTracker.Data.Repositories;
using TimeTracker.Presentation.Stores;

namespace TimeTracker.Presentation.ViewModels;

public class TimeRecorderViewModel : ViewModelBase
{
    private string _timerText;
    private DateTime _start;
    private DateTime _end;
    private DispatcherTimer _timer;
    private TimeSpan _time;

    private string _workItemText;

    private ObservableCollection<WorkItem> _workItems;

    private AppContextStore _appContextStore;
    private IRecordRepository _recordRepository;

    public TimeRecorderViewModel(
        AppContextStore appContextStore,
        IRecordRepository recordRepository,
        IWorkItemRepository workItemRepository,
        WorkItemListViewModel workItemListViewModel)
    {
        _recordRepository = recordRepository;
        _appContextStore = appContextStore;
        WorkItemListViewModel = workItemListViewModel;
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += Timer_Tick;
        TimerText = "00:00:00";

        SelectedWorkItem = new WorkItemViewModel(_appContextStore.SelectedWorkItem!);
    }

    public string TimerText
    {
        get => _timerText;
        set => SetProperty(ref _timerText, value);
    }

    public DateTime Start
    {
        get => _start;
        set => SetProperty(ref _start, value);
    }

    public DateTime End
    {
        get => _end;
        set => SetProperty(ref _end, value);
    }

    public RelayCommand StartTimerCommand => new(StartTimerExecute);
    public RelayCommand StopTimerCommand => new(StopTimerExecute);

    public WorkItemListViewModel WorkItemListViewModel { get; }
    public WorkItemViewModel SelectedWorkItem { get; set; }

    private void StartTimerExecute()
    {
        _timer.Start();
        Start = DateTime.Now;
    }

    private async void StopTimerExecute()
    {
        _timer.Stop();
        TimerText = "00:00:00";
        End = DateTime.Now;
        var record = new Record
        {
            Creator = _appContextStore.SelectedUser!,
            Project = _appContextStore.SelectedProject!,
            Start = Start,
            End = End,
            WorkItem = SelectedWorkItem.WorkItem,
            Duration = End - Start
        };
        await _recordRepository.AddAsync(record);
        _time = TimeSpan.Zero;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        _time = _time.Add(TimeSpan.FromSeconds(1));
        TimerText = _time.ToString();
    }
}