using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public interface ITimeOfSignificance
    {
        DateTime Time { get; }
        string Name { get; }
    }

    public class MajorTime : ITimeOfSignificance
    {
        public DateTime Time { get; }

        public string Name { get; }

        public MajorTime(DateTime time, string name)
        {
            Time = time;
            Name = name;
        }
    }
}
