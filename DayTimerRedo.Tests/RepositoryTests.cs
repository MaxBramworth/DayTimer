﻿using DayTimerRedo.Models;
using DayTimerRedo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTimerRedo.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GivenAnInvalidFilePathway_WhenPathwaySet_DoesNotSet()
        {
            CSVParser parser = new();

            parser.Pathway = "breaks";

            Assert.AreNotEqual("breaks", parser.Pathway);
        }

        [TestMethod]
        public void GivenAValidFilePathway_WhenPathwaySet_SetsThePathway()
        {
            CSVParser parser = new();

            string expectedPathway = "DataBase\\TimeEvents.csv";
            parser.Pathway = expectedPathway;

            Assert.IsTrue(File.Exists(expectedPathway));
            Assert.AreEqual(expectedPathway, parser.Pathway);
        }

        [TestMethod]
        public void GivenAValidFilePathwayWithInvalidType_WhenPathwaySet_DoesNotSet()
        {
            CSVParser parser = new();

            string expectedPathway = "DataBase\\TimeEvents.json";
            parser.Pathway = expectedPathway;

            Assert.IsTrue(File.Exists(expectedPathway));
            Assert.AreNotEqual(expectedPathway, parser.Pathway);
        }

        //[TestMethod]
        //public void GivenAFile_WhenReadAllTimeEventsInvoked_ReturnsAllTimeEvents()
        //{
        //    CSVParser parser = new();
        //    parser.Pathway = "DataBase\\TimeEvents.csv";

        //    ITimeEvent[] timeEvents = parser.ReadAllTimeEvents();

        //    Assert.AreEqual(3, timeEvents.Length);
        //}
    }
}
