using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DayTimerRedo.Models
{
    public class MainDayTimer
    {
        ITimeOfSignificance NextTime;

        public TimeSpan TimeRemaining => NextTime.Time - DateTime.Now;

        public async void BeginLoop()
        {
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

        }
    }
}
