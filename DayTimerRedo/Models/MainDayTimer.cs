using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DayTimerRedo.Viewmodels;
using DayTimerRedo.Repository;

namespace DayTimerRedo.Models
{
    public class MainDayTimer
    {
        public MainWindowViewModel ViewModel { get; set; }
        
        ITimeEvent? _nextTime;

        private TimeSpan _timeRemaining => _nextTime.Time - TimeOnly.FromDateTime(DateTime.Now);
        private TimeSpan _previousTimeRemaining;

        public TimeEventRepository Repository;

        public MainDayTimer()
        {
            Repository = new(new CSVParser("DataBase\\TimeEvents.csv"));
        }

        public async void BeginLoop()
        {
            _nextTime = GetNextTimeEvent(Repository.TimeEvents, DateTime.Now);

            int period = 1000;
            Func<Task> loopingUpdate = Update;

            while (true)
            {
                await loopingUpdate();
                await Task.Delay(period);
            }
        }

        private async Task Update()
        {
            if (TimeOnly.FromDateTime(DateTime.Now) > _nextTime.Time) // an overflow has happened (the event is now in the past)
            {
                NotificationService.ShowMessage(_nextTime.Name);
                _nextTime = GetNextTimeEvent(Repository.TimeEvents, DateTime.Now);
            }

            if (_nextTime != null)
            {
                _previousTimeRemaining = _timeRemaining;
                ViewModel.FormatTimeRemaining(_timeRemaining);
            }
            else
            {
                ViewModel.DisplayNoEventsRemaining();
            }

        }

        public ITimeEvent? GetNextTimeEvent(ITimeEvent[] timeEvents, DateTime currentTime)
        {
            timeEvents = timeEvents.Where(t => t.Days.Contains(currentTime.DayOfWeek)).OrderBy(t => t.Time).ToArray();

            foreach (ITimeEvent timeEvent in timeEvents)
            {
                if (timeEvent.Time > TimeOnly.FromDateTime(currentTime))
                {
                    ViewModel.TimeEventTitle = $"Until {timeEvent.Name}";
                    return timeEvent;
                }
            }

            return null;
        }
    }
}
