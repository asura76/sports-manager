using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LeagueGenLib;

namespace YellowTestProject
{
    [TestClass]
    public class LeagueTests
    {
        [TestInitialize]
        public void initializeLeague()
        {
            int NTeams = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, NTeams);
        }

        [TestMethod]
        public void setUpLeague()
        {
            int NTeams = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, NTeams);

            Assert.AreEqual(leagueName, myLeague.LeagueName);
        }

        [TestMethod]
        public void addTeamToLeague()
        {
            int maxTeams = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, maxTeams);

            const string teamName = "myTeam";
            Team myTeam = new Team(teamName);

            myLeague.addTeam(myTeam);

            Assert.AreEqual(teamName, myLeague.Teams[0].TeamName);
        }

        [TestMethod]
        public void fillLeagueWithTeams()
        {
            int maxTeams = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, maxTeams);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8);

            myLeague.addTeam(team1);
            myLeague.addTeam(team2);
            myLeague.addTeam(team3);
            myLeague.addTeam(team4);
            myLeague.addTeam(team5);
            myLeague.addTeam(team6);
            myLeague.addTeam(team7);
            myLeague.addTeam(team8);

            int teamsCurrentlyInLeague = 8;
            Assert.AreEqual(teamsCurrentlyInLeague, myLeague.Teams.Count);
        }

        [TestMethod]
        public void addTooManyTeams()
        {
            int maxTeams = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, maxTeams);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8);

            myLeague.addTeam(team1);
            myLeague.addTeam(team2);
            myLeague.addTeam(team3);
            myLeague.addTeam(team4);
            myLeague.addTeam(team5);
            myLeague.addTeam(team6);
            myLeague.addTeam(team7);
            myLeague.addTeam(team8);

            Assert.IsTrue(myLeague.Teams.Count <= maxTeams);
        }

        [TestMethod]
        public void removeTeams()
        {
            int maxTeams = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, maxTeams);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8);

            myLeague.addTeam(team1);
            myLeague.addTeam(team2);
            myLeague.addTeam(team3);
            myLeague.addTeam(team4);
            myLeague.addTeam(team5);
            myLeague.addTeam(team6);
            myLeague.addTeam(team7);
            myLeague.addTeam(team8);

            myLeague.removeTeam(team1);
            myLeague.removeTeam(team2);
            myLeague.removeTeam(team3);
            myLeague.removeTeam(team4);
            myLeague.removeTeam(team5);
            myLeague.removeTeam(team6);
            myLeague.removeTeam(team7);
            myLeague.removeTeam(team8);

            Assert.IsTrue(myLeague.Teams.Count == 0);
        }

        }
}
