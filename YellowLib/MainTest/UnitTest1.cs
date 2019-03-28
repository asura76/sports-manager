using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Main;
using FakeMainNameSpace;
using LeagueGenLib;

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

            Assert.AreEqual(leagueName, Main.Program.Leagues[Main.Program.Leagues.Count - 1].LeagueName);
            Assert.AreEqual(playoffTeams, Main.Program.Leagues[Main.Program.Leagues.Count - 1].NPlayoffTeams);
        }

        [TestMethod]
        public void getLeagueTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            League retLeague = Main.Program.getLeagueForTest(leagueName);
            Assert.AreEqual(null, retLeague);

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
            retLeague = Main.Program.getLeagueForTest(leagueName);
            Assert.AreEqual(leagueName, retLeague.LeagueName);
        }

        [TestMethod]
        public void addTeamTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);

            Assert.IsTrue(retLeague.containsTeam(teamName));
        }

    }
}
