using DayTimerRedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class StringParserTests
    {
        [TestMethod]
        public void GivenAString_WhenStringToTimeOnlyInvoked_ReturnsTimeOnly()
        {
            TimeOnly expected = new(15, 30, 45);
            TimeOnly actual = StringParser.StringToTimeOnly("15:30:45");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAString_WhenStringToDayOfWeekArrayInvoked_ReturnsDayOfWeekArray()
        {
            DayOfWeek[] expected = new DayOfWeek[]
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Saturday,
            };
            DayOfWeek[] actual = StringParser.StringToDayOfWeekArray("Mon NOPE Tues Sat");
        }
    }
}
