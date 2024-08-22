using System.Collections.Generic;
using DayTimerRedo.Models;

namespace DayTimerRedo.Repository
{
    public interface ITimeEventParser
    {
        string Pathway { get; set; }

        IEnumerable<ITimeEvent> ReadAllTimeEvents();
    }
}
