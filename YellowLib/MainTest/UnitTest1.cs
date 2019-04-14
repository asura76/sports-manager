using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Main;
using LeagueGenLib;


namespace MainTest
{
    [TestClass]
    public class UnitTest1
    {
        string leagueName;
        int playoffTeams;

        // clears all current leagues and generates a new "Test League"
        [TestInitialize]
        public void initilizeLeague()
        {
            Main.Program.Leagues.Clear();

            leagueName = "Test League";
            playoffTeams = 4;

            Main.Program.addLeagueForTest(leagueName, playoffTeams);
        }


        // this attempts to call the add league function that does not require
        // user prompted data, but Main does not seem to be able to be used
        // as a reference so we cannot call its functions from this test class
        [TestMethod]
        public void getIntTest()
        {
            String intVal = "5";
            String stringVal = "adsa";
           
            int expected = 5;
            int failValue = -999;

            int result = Main.Program.getInt(true, intVal);
            Assert.AreEqual(expected, result);

            //Pass a string ....
            result = Main.Program.getInt(true, stringVal);
            expected = failValue;
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void addLeagueTest()
        {
            Assert.AreEqual(leagueName, Main.Program.Leagues[Main.Program.Leagues.Count - 1].LeagueName);
            Assert.AreEqual(playoffTeams, Main.Program.Leagues[Main.Program.Leagues.Count - 1].NPlayoffTeams);
        }

        [TestMethod]
        public void getLeagueTest()
        {
            string leagueName = "Test League";
            int playoffTeams = 4;

            League retLeague = Main.Program.getLeagueForTest(leagueName);
            Assert.AreEqual(leagueName, retLeague.LeagueName);
        }

        [TestMethod]
        public void addTeamTest()
        {
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);

            Assert.IsTrue(retLeague.containsTeam(teamName));
        }

        [TestMethod]
        public void removeTeamTest()
        {
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
        [TestMethod]
        public void getIntValueTest()
        {
            int validLow = 1;
            int invalidInt2 = -1;
            string stringInput = "string";
            bool result = false;

            // Enter a string value to test the try catch statement in the main function.
            try
            {
               result = Main.Program.getIntValueForTest(1, stringInput);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                // do nothing
            }
            
            // number less than the min value
            result = Main.Program.getIntValueForTest(validLow, invalidInt2.ToString());
            Assert.IsFalse(result);

            // number = to the min value
            result = Main.Program.getIntValueForTest(validLow, validLow.ToString());
            Assert.IsTrue(result);

            // number > min value
            result = Main.Program.getIntValueForTest(validLow, (validLow + 1).ToString());
            Assert.IsTrue(result);

            string doubleTest = "3.14159";
            
            // Ensure a failure on a double...
            try
            {
                result = Main.Program.getIntValueForTest(validLow, doubleTest);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                // do nothing
            }
         
        }


        [TestMethod]
        public void saveDataWithSaveXMLTest()
        {
            League retLeague = Main.Program.getLeagueForTest(leagueName);

            string teamName = "Team 1";
            Main.Program.addTeamForTest(retLeague, teamName);
            string teamName2 = "Team 2";
            Main.Program.addTeamForTest(retLeague, teamName2);
            string teamName3 = "Team 3";
            Main.Program.addTeamForTest(retLeague, teamName3);
            string teamName4 = "Team 4";
            Main.Program.addTeamForTest(retLeague, teamName4);

            Team team1 = retLeague.Teams[0];
            Main.Program.addPlayerForTest(ref team1,"Bob", "Hill");
            Main.Program.addPlayerForTest(ref team1, "Jon", "Wick");
            Team team2 = retLeague.Teams[1];
            Main.Program.addPlayerForTest(ref team2, "Bob", "Hill");
            Main.Program.addPlayerForTest(ref team2, "Jon", "Wick");
            Team team3 = retLeague.Teams[2];
            Main.Program.addPlayerForTest(ref team3, "Bob", "Hill");
            Main.Program.addPlayerForTest(ref team3, "Jon", "Wick");



            IDataIO saveDataFake = new XMLDataIO();
            saveDataFake.saveData("fakeTest.xml");
            string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\fakeTest.xml";

            bool fileExists = System.IO.File.Exists(fileLocation);
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public void loadDataSaveXMLTest()
        {
            IDataIO saveDataFake = new XMLDataIO();

            string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\fakeTest.xml";

            saveDataFake.loadData("\\fakeTest.xml");
            Assert.IsTrue(Main.Program.Leagues.Count == 1);
            Assert.IsTrue(Main.Program.Leagues[0].Teams.Count == 4);
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Main.Program.Leagues[0].Teams[i].Players.Count == 2);
            }
            Assert.IsTrue(Main.Program.Leagues[0].Teams[3].Players.Count == 0);
        }

    }
}
