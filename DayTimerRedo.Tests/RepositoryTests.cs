using DayTimerRedo.Models;
using DayTimerRedo.Repository;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GivenADatabase_WhenConstructorInvoked_AutomaticallyReadsTheDatabase()
        {
            var parser = new CSVParser("DataBase\\TimeEvents.csv");
            var repo = new TimeEventRepository(parser);

            ITimeEvent[] expected = parser.ReadAllTimeEvents();

            Assert.AreEqual(expected.Length, repo.TimeEvents.Length);
            Assert.AreEqual(expected[0].Name, repo.TimeEvents[0].Name);
            Assert.AreEqual(expected[1].Name, repo.TimeEvents[1].Name);
        }
    }
}
