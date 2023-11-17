using System;

namespace DayTimerRedo.Models
{
    public class TimeFactory
    {
        public static MajorTimeEvent CreateMajorTimeEvent(string name, int hours, int mins) 
            => new MajorTimeEvent(DateTime.Today.AddHours(hours).AddMinutes(mins), name);
    }
}
