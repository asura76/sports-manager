using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LeagueGenLib;

namespace YellowTestProject
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void setupTeam()
        {
            const string teamName = "myTeam";
            Team myTeam = new Team(teamName);

            Assert.AreEqual(teamName, myTeam.teamName);
        }
        [TestMethod]
        public void setUpPlayer()
        {
            const string lastName = "LAST";
            const string firstName = "FIRST";
            Player myPlayer = new Player(lastName, firstName);

            Assert.Equals(lastName, myPlayer.lastName);
            Assert.Equals(firstName, myPlayer.firstName);
        }
     

    }
}
