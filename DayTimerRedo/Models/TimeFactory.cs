using System;
using System.Collections.Generic;

namespace DayTimerRedo.Models
{
    public class TimeFactory
    {
        public static MajorTimeEvent CreateMajorTimeEvent(string name, string time, string daysofweek)
        {
            MajorTimeEvent output = new();

            output.Name = name;
            output.Time = StringParser.StringToTimeOnly(time);
            output.Days = StringParser.StringToDayOfWeekArray(daysofweek);

            return output;
        }
    }
}
