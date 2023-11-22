using DayTimerRedo.Models;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class TimeFactoryTests
    {
        [TestMethod]
        public void GivenHoursAndMinutes_WhenCreateMajorTimeInvoked_ReturnsAMajorTimeEvent()
        {
            var timeEvent = TimeFactory.CreateMajorTimeEvent("aa", "4:30:0", "Mon");
            Assert.AreEqual("aa", timeEvent.Name);
            Assert.AreEqual(4, timeEvent.Time.Hour);
            Assert.AreEqual(30, timeEvent.Time.Minute);
            Assert.AreEqual(0, timeEvent.Time.Second);
            Assert.AreEqual(1, timeEvent.Days.Length);
            Assert.AreEqual(DayOfWeek.Monday, timeEvent.Days[0]);
        }
    }
}
