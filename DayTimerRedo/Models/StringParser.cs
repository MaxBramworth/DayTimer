using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Models
{
    public static class StringParser
    {
        public static TimeOnly StringToTimeOnly(string value)
        {
            string[] timeFields = value.Split(':');

            int hours = int.Parse(timeFields[0]);
            int minutes = int.Parse(timeFields[1]);
            int seconds = int.Parse(timeFields[2]);

            TimeOnly output = new(hours, minutes, seconds);

            return output;
        }

        public static DayOfWeek[] StringToDayOfWeekArray(string value)
        {
            List<DayOfWeek> output = new List<DayOfWeek>();
            string[] days = value.Split(":");

            foreach (var day in days)
            {
                switch (day)
                {
                    case "Mon":
                        output.Add(DayOfWeek.Monday);
                        break;
                    case "Tues":
                        output.Add(DayOfWeek.Tuesday);
                        break;
                    case "Wed":
                        output.Add(DayOfWeek.Wednesday);
                        break;
                    case "Thur":
                        output.Add(DayOfWeek.Thursday);
                        break;
                    case "Fri":
                        output.Add(DayOfWeek.Friday);
                        break;
                    case "Sat":
                        output.Add(DayOfWeek.Saturday);
                        break;
                    case "Sun":
                        output.Add(DayOfWeek.Sunday);
                        break;
                }
            }

            return output.ToArray();
        }
    }
}
