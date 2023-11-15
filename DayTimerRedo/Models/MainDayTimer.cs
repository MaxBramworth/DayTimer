using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public class MainDayTimer
    {
        ITimeOfSignificance NextTime;

        public TimeSpan TimeRemaining => NextTime.Time - DateTime.Now;
    }
}
