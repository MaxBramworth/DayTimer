using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public interface ITimeEvent
    {
        TimeOnly Time { get; set; }
        string Name { get; set; }
        DayOfWeek[] Days { get; set; }
    }

    public class MajorTimeEvent : ITimeEvent
    {
        public TimeOnly Time { get; set; }

        public string Name { get; set; }

        public DayOfWeek[] Days { get; set; }

        public MajorTimeEvent(TimeOnly time, string name, DayOfWeek[] days)
        {
            Time = time;
            Name = name;
            Days = days;
        }
    }
}
