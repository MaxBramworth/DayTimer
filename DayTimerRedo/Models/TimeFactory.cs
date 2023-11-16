using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public class TimeFactory
    {
        public static MajorTime CreateMajorTimeEvent(string name, int hours, int mins) 
            => new MajorTime(DateTime.Today.AddHours(hours).AddMinutes(mins), name);
    }
}
