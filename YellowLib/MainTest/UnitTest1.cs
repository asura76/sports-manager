using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Main;
using FakeMainNameSpace;

namespace MainTest
{
    [TestClass]
    public class UnitTest1
    {
        // this attempts to call the add league function that does not require
        // user prompted data, but Main does not seem to be able to be used
        // as a reference so we cannot call its functions from this test class
        [TestMethod]
        public void addLeagueTest()
        {
                    
            string leagueName = "Test League";
            int playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);

            Assert.AreEqual(leagueName, Main.Program.Leagues[Main.Program.Leagues.Count-1].LeagueName);
            Assert.AreEqual(playoffTeams, Main.Program.Leagues[Main.Program.Leagues.Count - 1].NPlayoffTeams);


        }
    }
}
