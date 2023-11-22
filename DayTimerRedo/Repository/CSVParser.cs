using DayTimerRedo.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

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

        public CSVParser() { }

        public CSVParser(string pathway)
        {
            Pathway = pathway;
        }

        public ITimeEvent[] ReadAllTimeEvents()
        {
            TextFieldParser parser = new(Pathway);
            parser.SetDelimiters(",");
            parser.CommentTokens = new string[] { "/" };

            List<ITimeEvent> events = new();
            string[]? fields = parser.ReadFields();

            while (fields != null)
            {
                events.Add(TimeFactory.CreateMajorTimeEvent(fields[0], fields[1], fields[2]));
                fields = parser.ReadFields();
            }

            return events.ToArray();
        }
    }
}
