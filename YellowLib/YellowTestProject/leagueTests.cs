using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

using LeagueGenLib;

namespace YellowTestProject
{
    [TestClass]
    public class LeagueTests
    {
        [TestInitialize]
        public void initializeLeague()
        {
            const int MAX_TEAMS = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);
        }

        [TestMethod]
        public void setUpLeague()
        {
            const int MAX_TEAMS = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            Assert.AreEqual(leagueName, myLeague.LeagueName);
        }

        [TestMethod]
        // add a team to a lague
        public void addTeamToLeague()
        {
            const int MAX_TEAMS = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName = "myTeam";
            Team myTeam = new Team(teamName, myLeague);

            myLeague.addTeam(myTeam);

            Assert.AreEqual(teamName, myLeague.Teams[0].TeamName);
        }

        [TestMethod]
        // add multiple teams to a league and make sure they
        // were all added successfully
        public void fillLeagueWithTeams()
        {
            const int MAX_TEAMS = 10;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1, myLeague);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2, myLeague);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3, myLeague);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4, myLeague);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5, myLeague);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6, myLeague);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7, myLeague);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8, myLeague);

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
        // add one too many teams than the league's max teams
        // and make sure the league does not allow that team be added
        public void addTooManyTeams()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1, myLeague);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2, myLeague);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3, myLeague);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4, myLeague);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5, myLeague);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6, myLeague);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7, myLeague);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8, myLeague);

            myLeague.addTeam(team1);
            myLeague.addTeam(team2);
            myLeague.addTeam(team3);
            myLeague.addTeam(team4);
            myLeague.addTeam(team5);
            myLeague.addTeam(team6);
            myLeague.addTeam(team7);
            myLeague.addTeam(team8);

            Assert.IsTrue(myLeague.Teams.Count <= MAX_TEAMS);
        }

        [TestMethod]
        // test to remove teams from league
        public void removeTeams()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1, myLeague);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2, myLeague);
            const string teamName3 = "team3";
            Team team3 = new Team(teamName3, myLeague);
            const string teamName4 = "team4";
            Team team4 = new Team(teamName4, myLeague);
            const string teamName5 = "team5";
            Team team5 = new Team(teamName5, myLeague);
            const string teamName6 = "team6";
            Team team6 = new Team(teamName6, myLeague);
            const string teamName7 = "team7";
            Team team7 = new Team(teamName7, myLeague);
            const string teamName8 = "team8";
            Team team8 = new Team(teamName8, myLeague);

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

        [TestMethod]
        public void generateAGame()
        {
            const int MAX_TEAMS = 7;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            const string teamName1 = "team1";
            Team team1 = new Team(teamName1, myLeague);
            const string teamName2 = "team2";
            Team team2 = new Team(teamName2, myLeague);

            Game firstGame = new Game(team1, team2);
            myLeague.addGameToSchedule(firstGame);

        }

        [TestMethod]
        public void generateASchedule()
        {
            const int MAX_TEAMS = 8;
            string leagueName = "My League";
            League myLeague = new League(leagueName, MAX_TEAMS);

            Team tmpTeam;

            String[] teamNames = new String[MAX_TEAMS];

            List<Team> teams = new List<Team>();

            for (int i = 0; i < MAX_TEAMS; i++)
            {
                teamNames[i] = "team" + i;
                tmpTeam = new Team(teamNames[i], myLeague);
                teams.Add(tmpTeam);
            }
            //Game firstGame = new Game(team1, team2);
            int nTeams = 8;
            int nGames = nTeams / 2;
            Game[,] mySchedule = myLeague.generateSchedule(nTeams, teams);
            bool areEqual = false;

            Game tmpGame;
           //Sweep through the schedule to ensure there are no duplicate games.
            for (int i =0; i < nGames; i++)
            {
                
                for (int j = 0; j < nGames; j++)
                {
                    tmpGame = mySchedule[i, j];

                    for (int k = 0; k < nGames; k++)
                    {
                        areEqual = tmpGame == mySchedule[k, j];
                        //If the loop is not = to tmpGame's index...
                        if (k != i && k != j)
                        {                            
                            Assert.IsFalse(areEqual);
                        }
                       
                    }
                   
                }
            }
           
        }
    }
}
