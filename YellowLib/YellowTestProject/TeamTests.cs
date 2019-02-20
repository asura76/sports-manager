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
            const string teamName = "myTeam";
            Team myTeam = new Team(teamName);

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
     

    }
}
