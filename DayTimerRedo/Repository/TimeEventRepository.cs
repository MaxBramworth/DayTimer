using DayTimerRedo.Models;

namespace DayTimerRedo.Repository
{
    public class TimeEventRepository
    {
        public ITimeEventParser Parser { get; set; }
        public ITimeEvent[] TimeEvents { get; private set; }

        public TimeEventRepository(ITimeEventParser db)
        {
            Parser = db;
            TimeEvents = Parser.ReadAllTimeEvents();
        }

        public void RefreshTimeEvents()
        {
            TimeEvents = Parser.ReadAllTimeEvents();
        }
    }
}
