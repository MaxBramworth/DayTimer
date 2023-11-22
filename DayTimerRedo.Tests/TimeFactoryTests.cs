using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayTimerRedo;
using DayTimerRedo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class TimeFactoryTests
    {
        [TestMethod]
        public void GivenHoursAndMinutes_WhenCreateMajorTimeInvoked_ReturnsAMajorTimeEvent()
        {
            var time = TimeFactory.CreateMajorTimeEvent("aa", "4:30:0", "Mon");
            Assert.AreEqual("aa", time.Name);
            Assert.AreEqual(4, time.Time.Hour);
            Assert.AreEqual(30, time.Time.Minute);
        }

        [TestMethod]
        public void GivenAString_WhenStringToTimeOnlyInvoked_ReturnsTimeOnly()
        {
            TimeOnly expected = new(15, 30, 45);
            TimeOnly actual = TimeFactory.StringToTimeOnly("15:30:45");
            Assert.AreEqual(expected, actual);
        }
    }
}
