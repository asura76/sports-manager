using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Main; // doesn't work as a reference

namespace MainTest
{
    [TestClass]
    public class UnitTest1
    {
        // this attempts to call the add league function that does not require
        // user prompted data, but Main does not seem to be able to be used
        // as a reference so we cannot call its functions from this test class
        //[TestMethod]
        //public void addLeagueTest()
        //{
        //    string leagueName = "Test League";
        //    int playoffTeams = 4;

        //    addLeagueForTest(leagueName, playoffTeams);
        //}
    }
}
