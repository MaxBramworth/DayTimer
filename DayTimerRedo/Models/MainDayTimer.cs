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
        
        ITimeEvent? NextTime;

        public TimeSpan TimeRemaining => NextTime.Time - TimeOnly.FromDateTime(DateTime.Now);

        public TimeEventRepository Repository;

        public MainDayTimer()
        {
            Repository = new(new CSVParser("DataBase\\TimeEvents.csv"));
        }

        public async void BeginLoop()
        {
            NextTime = GetNextTimeEvent(Repository.TimeEvents, DateTime.Now);

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
            ViewModel.FormatTimeRemaining(TimeRemaining);
        }

        public ITimeEvent? GetNextTimeEvent(ITimeEvent[] timeEvents, DateTime currentTime)
        {
            timeEvents = timeEvents.Where(t => t.Days.Contains(currentTime.DayOfWeek)).OrderBy(t => t.Time).ToArray();

            foreach (ITimeEvent timeEvent in timeEvents)
            {
                if (timeEvent.Time > TimeOnly.FromDateTime(currentTime))
                {
                    return timeEvent;
                }
            }

            return null;
        }
    }
}
