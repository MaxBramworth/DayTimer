using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTimerRedo;
using DayTimerRedo.Models;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class TimeFactoryTests
    {
        [TestMethod]
        public void GivenHoursAndMinutes_WhenCreateMajorTimeInvoked_ReturnsAMajorTimeEvent()
        {
            var time = TimeFactory.CreateMajorTimeEvent("aa", 4, 30);
            Assert.AreEqual("aa", time.Name);
            Assert.AreEqual(4, time.Time.Hour);
            Assert.AreEqual(30, time.Time.Minute);
        }
    }
}
