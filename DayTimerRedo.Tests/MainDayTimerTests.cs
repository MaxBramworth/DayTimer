using DayTimerRedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class MainDayTimerTests
    {
        [TestMethod]
        public void GivenAnArrayOfTimeEvents_WhenGetNextTimeEventInvoked_ReturnsTheNextTimeEventInTime()
        {
            var allDays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,
                DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };

            var inputTimeEvents = new ITimeEvent[]
            {
                new MajorTimeEvent(new(2, 30), "a", allDays),
                new MajorTimeEvent(new(5, 40), "b", allDays)
            };
            MainDayTimer mdt = new();

            ITimeEvent? result = mdt.GetNextTimeEvent(inputTimeEvents, new(2023, 11, 23, 3, 42, 30));

            Assert.AreEqual(inputTimeEvents[1].Name, result.Name);
            Assert.AreEqual(inputTimeEvents[1].Time, result.Time);
        }
    }
}
