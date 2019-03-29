﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Main;
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

        [TestMethod]
        public void removeTeamTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);
            string teamName2 = "Team 2";
            Main.Program.addTeamForTest(retLeague, teamName2);

            bool remSuccess = Main.Program.removeTeamForTest(ref retLeague, teamName);

            Assert.AreEqual(1, retLeague.Teams.Count);
            Assert.IsTrue(remSuccess);
            Assert.IsFalse(Main.Program.removeTeamForTest(ref retLeague, teamName));
        }

        // add/remove player

        [TestMethod]
        public void generateScheduleTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);
            string teamName2 = "Team 2";
            Main.Program.addTeamForTest(retLeague, teamName2);
            string teamName3 = "Team 3";
            Main.Program.addTeamForTest(retLeague, teamName3);
            string teamName4 = "Team 4";
            Main.Program.addTeamForTest(retLeague, teamName4);

            int nWeeks = 10;
            Main.Program.generateLeagueScheduleForTest(retLeague, nWeeks);
            Assert.AreEqual(nWeeks, retLeague.Schedule.GetLength(0));
        }

        [TestMethod]
        public void setScoresTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);
            string teamName2 = "Team 2";
            Main.Program.addTeamForTest(retLeague, teamName2);
            string teamName3 = "Team 3";
            Main.Program.addTeamForTest(retLeague, teamName3);
            string teamName4 = "Team 4";
            Main.Program.addTeamForTest(retLeague, teamName4);

            int nWeeks = 10;
            Main.Program.generateLeagueScheduleForTest(retLeague, nWeeks);



        }
    }
}
