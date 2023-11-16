using DayTimerRedo;
using DayTimerRedo.Viewmodels;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void GivenATimeSpan_WhenFormatTimeRemainingInvoked_ReturnsFormattedTime()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(61);
            MainWindowViewModel VM = new();

            VM.FormatTimeRemaining(timeSpan);

            Assert.AreEqual("00:01.01", VM.TimeRemainingFormatted);
        }
    }
}