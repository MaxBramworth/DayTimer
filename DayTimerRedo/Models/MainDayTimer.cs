using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DayTimerRedo.Viewmodels;

namespace DayTimerRedo.Models
{
    public class MainDayTimer
    {
        public MainWindowViewModel ViewModel { get; set; }
        
        ITimeOfSignificance NextTime;

        public TimeSpan TimeRemaining => NextTime.Time - DateTime.Now;

        public async void BeginLoop()
        {
            NextTime = TimeFactory.CreateMajorTimeEvent("Lunch", 12, 0);
            ViewModel.TimeEventTitle = NextTime.Name;

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
    }
}
