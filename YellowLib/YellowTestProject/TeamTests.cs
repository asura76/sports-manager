using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LeagueGenLib;

namespace YellowTestProject
{
    [TestClass]
    public class TeamTests
    {
        // need to add "Record" to this
        [TestMethod]
        public void setupTeam()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS); 

            const string teamName = "myTeam";
            Team myTeam = new Team(teamName, myLeague);

            Assert.AreEqual(teamName, myTeam.TeamName);
        }
        [TestMethod]
        public void setUpPlayer()
        {
            const string lastName = "LAST";
            const string firstName = "FIRST";
            Player myPlayer = new Player(lastName, firstName);

            Assert.AreEqual(lastName, myPlayer.LastName);
            Assert.AreEqual(firstName, myPlayer.FirstName);
        }

        [TestMethod]
        // test to add a player to a team
        public void addPlayerToTeam()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName = "myTeam";
            Team myTeam = new Team(teamName, myLeague);

            const string lastName = "LAST";
            const string firstName = "FIRST";
            Player myPlayer = new Player(lastName, firstName);

            myTeam.addPlayer(myPlayer);

            // make sure player adds successfully
            Assert.AreEqual(myPlayer, myTeam.Players[0]);

            // make sure a player cannot be added twice
            myTeam.addPlayer(myPlayer);
            Assert.AreEqual(1, myTeam.Players.Count);
        }

        [TestMethod]
        // test to remove a player from a team
        public void removePlayerFromTeam()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName = "myTeam";
            Team myTeam = new Team(teamName, myLeague);

            const string lastName = "LAST";
            const string firstName = "FIRST";
            Player myPlayer = new Player(lastName, firstName);
            Player player2 = new Player(lastName, firstName);
            Player player3 = new Player(lastName, firstName);

            myTeam.addPlayer(myPlayer);
            myTeam.addPlayer(player2);
            myTeam.addPlayer(player3);

            myTeam.removePlayer(myPlayer);

            Assert.AreEqual(2, myTeam.Players.Count);

        }
    }
}
