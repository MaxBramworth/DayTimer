using System;

namespace DayTimerRedo.Models
{
    public class TimeFactory
    {
        public static MajorTimeEvent CreateMajorTimeEvent(string name, string time, string daysofweek)
        {
            MajorTimeEvent output = new(
                StringParser.StringToTimeOnly(time), 
                name, 
                StringParser.StringToDayOfWeekArray(daysofweek));

            return output;
        }

        public static MajorTimeEvent CreateMajorTimeEvent(string name, TimeOnly time, string daysofweek)
        {
            MajorTimeEvent output = new(
                time,
                name,
                StringParser.StringToDayOfWeekArray(daysofweek));

            return output;
        }
    }
}
