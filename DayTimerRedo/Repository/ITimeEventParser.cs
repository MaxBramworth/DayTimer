using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DayTimerRedo.Models;

namespace DayTimerRedo.Repository
{
    interface ITimeEventParser
    {
        string Pathway { get; set; }

        ITimeEvent[] ReadAllTimeEvents();
    }
}
