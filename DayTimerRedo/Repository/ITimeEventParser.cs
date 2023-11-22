using DayTimerRedo.Models;

namespace DayTimerRedo.Repository
{
    public interface ITimeEventParser
    {
        string Pathway { get; set; }

        ITimeEvent[] ReadAllTimeEvents();
    }
}
