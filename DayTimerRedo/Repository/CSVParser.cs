using DayTimerRedo.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Repository
{
    public class CSVParser : ITimeEventParser
    {
        private string _pathway = "DB not set";
        public string Pathway { 
            get => _pathway; 
            set 
            {
                if (File.Exists(value) && value.Substring(Math.Max(value.Length-3, 0)) == "csv")
                {
                    _pathway = value; 
                }
            } 
        }
        public ITimeEvent[] ReadAllTimeEvents()
        {
            TextFieldParser parser = new(Pathway);
            parser.SetDelimiters(",");
            parser.CommentTokens = new string[] { "/" };

            List<ITimeEvent> events = new();
            string[] fields = parser.ReadFields();

            while (fields != null)
            {

            }

            return events.ToArray();
        }
    }
}
