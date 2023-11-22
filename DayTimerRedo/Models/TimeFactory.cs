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

            output.Time = StringToTimeOnly(time);

            string[] days = daysofweek.Split(' ');

            return output;
        }

        public static TimeOnly StringToTimeOnly(string value)
        {
            string[] timeFields = value.Split(':');

            int hours = int.Parse(timeFields[0]);
            int minutes = int.Parse(timeFields[1]);
            int seconds = int.Parse(timeFields[2]);

            TimeOnly output = new(hours, minutes, seconds);

            return output;
        }
    }
}
