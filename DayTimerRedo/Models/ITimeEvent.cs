using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public interface ITimeEvent
    {
        DateTime Time { get; }
        string Name { get; }
    }

    public class MajorTimeEvent : ITimeEvent
    {
        public DateTime Time { get; }

        public string Name { get; }

        public MajorTimeEvent(DateTime time, string name)
        {
            Time = time;
            Name = name;
        }
    }
}
