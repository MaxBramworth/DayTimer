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
            var inputTimeEvents = new ITimeEvent[]
            {
                new MajorTimeEvent(new(2, 30), "a", new DayOfWeek[] { DayOfWeek.Monday }),
                new MajorTimeEvent(new(5, 40), "b", new DayOfWeek[] { DayOfWeek.Monday }),
            };
            MainDayTimer mdt = new();

            ITimeEvent? result = mdt.GetNextTimeEvent(inputTimeEvents, new(3, 0));

            Assert.AreEqual(inputTimeEvents[1].Name, result.Name);
            Assert.AreEqual(inputTimeEvents[1].Time, result.Time);
        }
    }
}
