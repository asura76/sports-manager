﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueGenLib;
using System.Xml;
using System.IO;

namespace Main 
{
    public class Program 
    {

        public static List<League> Leagues = new List<League>();
        static string leagueName;
        static int numberWeeks = 0;
        public static IDataIO saveInterface = new XMLDataIO();

        public Program()
        {

        }
        public static int getSelection()
        {
            //string input;
            int inputToInt;
            do
            {
                // a next step is sub options for a league/team
                Console.WriteLine("Select option: \n" +
                "1. Create a new league. \n" +
                "2. Display teams in league \n" +
                "3. Add team to league \n" +
                "4. Remove team from league. \n" +
                "5. Display team record and roster \n" +
                "6. Add player to team \n" +
                "7. Remove player from team \n" +
                "8. Generate league schedule \n" +
                "9. Display league schedule \n" +
                "10. Set scores in schedule \n" +
                "11. Save to file \n" +
                "12. Quit");

                inputToInt = getInt();

                executeSelection(inputToInt);

            } while (inputToInt != 12);

            return inputToInt;
        }
        // This function keeps the user in the loop until the enter a valid integer
        // The fake is used to test the functionality. If fake is used, the user input
        // will be the value of the "value" parameter
        public static int getInt(Boolean fake = false, String value = "0")
        {
            string input;
            int inputToInt = 0;
            Boolean good = false;

            while(!good)
            {
                try
                {
                    if(!fake)
                    {
                        input = Console.ReadLine();                      
                    }
                    else
                    {
                        input = value;
                    }
                    inputToInt = int.Parse(input);
                    good = true;

                }
                catch (Exception ex)
                {
                    if (fake) {
                        good = true;
                        inputToInt = -999; }
                    else { Console.WriteLine("Please enter an integer value!"); }
                }
            }
            
            return inputToInt;
         
        }


        //Saves all information in interface to file
        public static void saveToFile()
        {
            saveInterface.saveData("test.xml");
            
        }

        // Gets number of teams for playoffs
        public static int getNumberOfPlayoffTeams()
        {
            string strTeams;
            int nTeams = 0;
            bool valid = false;

            do
            {
                try
                {
                    strTeams = Console.ReadLine();
                    nTeams = int.Parse(strTeams);
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter an integer!");
                }
            } while (!valid || nTeams < 0); // 0 would indicate the user does not want a playoff.

            return nTeams;
        }


        // create a new league and add to Leagues list
        public static void addLeague()

        {
            Console.WriteLine("Enter league name: ");
            leagueName = Console.ReadLine();
            Console.WriteLine("Enter number of playoff teams: ");

            int nPlayoffTeams = getNumberOfPlayoffTeams();

            League newLeague = new League(leagueName, nPlayoffTeams);
            Leagues.Add(newLeague);
        }

        // create a new league and add to Leagues list - for test class
        public static void addLeagueForTest(string leagueName, int nPlayoffTeams)
        {
            League newLeague = new League(leagueName, nPlayoffTeams);
            Leagues.Add(newLeague);
        }

        // Returns league if league exists
        public static League LeagueExists(int leagueCounter)
        {
            League result = null;
            if (leagueCounter < Leagues.Count)
            {
                result = Leagues[leagueCounter];
            }

            return result;
        }


        // Returns the league the user wants or null if that
        // league does not exist in the Leagues list
        public static League getLeague()
        {
            League result = null;
            if (Leagues.Count > 0)
            {
                Console.WriteLine("Current leagues: ");
                foreach (League league in Leagues)
                {
                    Console.Write(league.LeagueName + Environment.NewLine);
                }
                Console.WriteLine("Select a league from the above list: ");
                string readLeague = Console.ReadLine();
                int leagueCounter = 0;

                while (leagueCounter < Leagues.Count() &&
                    Leagues[leagueCounter].LeagueName != readLeague)
                {
                    ++leagueCounter;
                }

                result = LeagueExists(leagueCounter);
                if (result == null) 
                {
                    Console.WriteLine("There are no leagues!");
                }
            }
            else { Console.WriteLine("There are no leagues!"); }

            Console.WriteLine(Environment.NewLine);
            return result;
        }

        // Returns the league the user wants or null if that
        // league does not exist in the Leagues list
        public static League getLeagueForTest(string leagueName)
        {
            League result = null;
            if (Leagues.Count > 0)
            {
                int leagueCounter = 0;
                while (leagueCounter < Leagues.Count() &&
                    Leagues[leagueCounter].LeagueName != leagueName)
                {
                    ++leagueCounter;
                }

                if (leagueCounter < Leagues.Count)
                {
                    result = Leagues[leagueCounter];
                }
            }

            return result;
        }


        public static bool getIntValueForTest(int minValue, string inputString)
        {
            string strWeeks;
            int userInput = 0;
            bool valid = false;

            try
            {
                strWeeks = inputString;
                userInput = int.Parse(strWeeks);
                if (userInput >= minValue) { valid = true; }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Please enter an integer!");
            }


            return valid;
        }
        public static int getIntValue(int minValue)
        {
            // This function gets an integer value from the user and 
            // verifies that the input is greater than the min value
            // and that it is a valid integer.
            bool valid = false;
            string strWeeks;
            int userInput = 0;
            do
            {
                try
                {
                    strWeeks = Console.ReadLine();
                    userInput = int.Parse(strWeeks);
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter an integer!");
                }
            } while (!valid || userInput < minValue);

            return userInput;
        }

        public static void generateLeagueSchedule(League league)
        {
            Console.WriteLine("How many weeks of games?");
            int nWeeks = getIntValue(1);

            league.generateSchedule(nWeeks, league.Teams);
        }
        public static void generateLeagueScheduleForTest(League league, int nWeeks)
        {
            league.generateSchedule(nWeeks, league.Teams);
        }

        // this is going to print out the schedule of the league,
        // but we have to figure out the best way to print the 2D array of games
        public static void displaySchedule(League league)
        {
            league.printSchedule();
        }

        // Add new team to the league passed in
        public static void addTeam(League league)
        {
            Console.WriteLine("Enter team name: ");
            string readTeam = Console.ReadLine();

            Team teamToAdd = new Team(readTeam, league);
            league.addTeam(teamToAdd);
        }
       
        // Add new team to the league passed in
        public static void addTeamForTest(League league, string teamName)
        {
            Team teamToAdd = new Team(teamName, league);
            league.addTeam(teamToAdd);
        }

        // Add new team to the league passed in and return that new team
        public static Team addAndGetTeamForTest(League league, string teamName)
        {
            Team teamToAdd = new Team(teamName, league);
            league.addTeam(teamToAdd);

            return teamToAdd;
        }

        public static void printTeams(League league)
        {
            foreach (Team team in league.Teams)
            {
                Console.WriteLine(team.TeamName + "\n");
            }
        }

        // Returns the team the user wants or null if that 
        // team does not exist in the league passed in 
        public static void removeTeam(ref League league)
        {
            string readTeam;
            if (league != null && league.Teams.Count > 0)
            {
                int counter = 0;
                Console.WriteLine("Current teams: ");
                printTeams(league);

                bool teamNameFound = false;
                do
                {
                    Console.WriteLine("Enter team name: ");
                    readTeam = Console.ReadLine();
                    while (counter < league.Teams.Count &&
                        teamNameFound == false)
                    {
                        if (league.Teams[counter].TeamName == readTeam)
                        {
                            teamNameFound = true;
                            league.removeTeam(league.Teams[counter]);

                        }
                        counter++;
                    }
                    if (!teamNameFound)
                    {
                        Console.WriteLine("Team name not found");
                    }
                } while (!teamNameFound);

            }
            else { Console.WriteLine("There are no teams to remove!"); }

        }

        // Removes the team that's name was passed in or returns false
        // if the team was not found
        public static bool removeTeamForTest(ref League league, string teamName)
        {
            bool result = false;
            if (league != null && league.Teams.Count > 0)
            {
                int counter = 0;

                bool teamNameFound = false;

                while (counter < league.Teams.Count &&
                    teamNameFound == false)
                {
                    if (league.Teams[counter].TeamName == teamName)
                    {
                        teamNameFound = true;
                        result = true;
                        league.removeTeam(league.Teams[counter]);
                    }
                    counter++;
                }
            }

            return result;
        }

        static void displayTeamsInLeague(League league)
        {
            Console.WriteLine("Teams in league: ");
            printTeams(league);
        }

        // returns the team that the user enters if it exists in league
        static Team getTeam(ref League league)
        {
            string readTeam;
            Team result = null;
            int counter = 0;
            if (league != null && league.Teams.Count > 0)
            {
                displayTeamsInLeague(league);

                bool teamNameFound = false;
                do
                {
                    Console.WriteLine("Enter team name: ");
                    readTeam = Console.ReadLine();
                    while (counter < league.Teams.Count && teamNameFound == false)
                    {
                        if (league.Teams[counter].TeamName == readTeam)
                        {
                            teamNameFound = true;
                            result = league.Teams[counter];
                        }
                        counter++;
                    }
                    if (!teamNameFound)
                    {
                        Console.WriteLine("Team name not found");
                    }
                } while (!teamNameFound);

            }
            else { Console.WriteLine("There are no teams in this league!"); }

            return result;
        }

        public static void printPlayers(Team team)
        {
            foreach (Player player in team.Players)
            {
                Console.WriteLine(player.FirstName + " " + player.LastName + "\n");
            }
        }

        // display a team's current record and roster
        static void displayRecordAndRoster(Team team)
        {
            Console.WriteLine(team.TeamName + "Record: " +
                team.Record[0] + "-" + team.Record[1] + "\n");

            Console.WriteLine("Current roster: ");
            
            printPlayers(team);
        }

        // Add a new player to the team passed in
        static void addPlayer(ref Team team)
        {
            string fName;
            string lName;
            Console.WriteLine("New player: "
              + Environment.NewLine + "First name: ");
            fName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            lName = Console.ReadLine();

            Player newPlayer = new Player(lName, fName);
            team.addPlayer(newPlayer);
        }

        public static void addPlayerForTest(ref Team team, string fName, string lName)
        {
            Player newPlayer = new Player(lName, fName);
            team.addPlayer(newPlayer);
        }

        public static void removePlayer(ref Team theTeam)
        {
            string readFirstName, readLastName;
            int PlayerCount = theTeam.Players.Count;

            if (theTeam != null && PlayerCount > 0)
            {
                int counter = 0;
                Console.WriteLine("Current players on this team: ");
                printPlayers(theTeam);

                bool playerNameFound = false;
                do
                {
                    Console.WriteLine("Enter first name: ");
                    readFirstName = Console.ReadLine();
                    while (counter < PlayerCount && playerNameFound == false)
                    {
                        if (theTeam.Players[counter].FirstName == readFirstName)
                        {
                            Console.WriteLine("Enter last name: ");
                            readLastName = Console.ReadLine();
                            if (theTeam.Players[counter].LastName == readLastName)
                            {
                                playerNameFound = true;
                                theTeam.removePlayer(theTeam.Players[counter]);
                            }

                        }
                        counter++;
                    }
                    if (!playerNameFound)
                    {
                        Console.WriteLine("Player name not found");
                    }
                } while (!playerNameFound);

            }
            else { Console.WriteLine("There are no players to remove!"); }
        }

        public static void SetResults(ref League league)
        {
            Team FirstTeam, SecondTeam;
            bool GameFound = false;

            Console.WriteLine("Enter Home and Away Teams \n"
                + "Home: \n");
            FirstTeam = getTeam(ref league);
            Console.WriteLine("Away: \n");
            SecondTeam = getTeam(ref league);

            int week = 0, games = 0;
            while (GameFound != true &&
                week <= league.Schedule.GetLength(0))
            {
                games = 0;
                while (GameFound != true &&
                    games <= league.Schedule.GetLength(1))
                {
                    if(league.Schedule[week, games].Home == FirstTeam &&
                        league.Schedule[week, games].Away == SecondTeam)
                    {
                        GameFound = true;
                        Console.WriteLine("Enter score of Home team");
                        league.Schedule[week, games].setScore(FirstTeam.TeamName, getInt());
                        Console.WriteLine("Enter score of Away team");
                        league.Schedule[week, games].setScore(SecondTeam.TeamName, getInt());
                    }

                    ++games;
                }

                ++week;
            }

            if (GameFound == false)
            {
                Console.WriteLine("There were no games between Home: " + FirstTeam.TeamName +
                    " and Away: " + SecondTeam.TeamName + "\n");
            }

        }

        static void executeSelection(int input)
        {
            switch (input)
            {
                case 1:
                    addLeague();
                    break;
                case 2:
                    League leagueToDisplay = getLeague();
                    if (leagueToDisplay != null)
                    {
                        displayTeamsInLeague(leagueToDisplay);
                    }
                    break;
                case 3:
                    League leagueToAddTo = getLeague();
                    if (leagueToAddTo != null)
                    {
                        addTeam(leagueToAddTo);
                    }
                    break;
                case 4:
                    League leagueToRemoveFrom = getLeague();
                    if (leagueToRemoveFrom != null)
                    {
                        removeTeam(ref leagueToRemoveFrom);
                    }

                    break;
                case 5:
                    // display record and roster
                    League leagueToDisplayTeam = getLeague();
                    if (leagueToDisplayTeam != null)
                    {
                        Team theTeam = getTeam(ref leagueToDisplayTeam);
                        if (theTeam != null)
                        {
                            displayRecordAndRoster(theTeam);
                        }
                    }
                    break;
                case 6:
                    League leagueToAddPlayer = getLeague();
                    if (leagueToAddPlayer != null)
                    {
                        Team theTeam = getTeam(ref leagueToAddPlayer);
                        if (theTeam != null)
                        {
                            addPlayer(ref theTeam);
                        }
                    }
                    break;
                case 7:
                    League leagueToRemovePlayer = getLeague();
                    if (leagueToRemovePlayer != null)
                    {
                        Team theTeam = getTeam(ref leagueToRemovePlayer);
                        if (theTeam != null)
                        {
                            removePlayer(ref theTeam);
                        }
                    }
                    break;
                case 8:
                    League leagueToGenerateSched = getLeague();
                    if (leagueToGenerateSched != null)
                    {
                        generateLeagueSchedule(leagueToGenerateSched);
                    }
                    break;
                case 9:
                    League leagueToDisplaySched = getLeague();
                    if (leagueToDisplaySched != null)
                    {
                        displaySchedule(leagueToDisplaySched);
                    }
                    break;
                case 10:
                    League leagueToSetScore = getLeague();
                    if (leagueToSetScore != null)
                    {
                        SetResults(ref leagueToSetScore);
                    }
                    break;
                case 11:
                    saveToFile();
                    break;
                case 12:
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }


        static void Main(string[] args)
        {
            int QUIT = 12;
            int selection;
            do
            {
                selection = getSelection();
            } while (selection != QUIT);

        }
    }
}
