using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueGenLib;
namespace Main
{
    class Program
    {

        static List<League> Leagues = new List<League>();
        static string leagueName;

        static int getSelection()
        {
            //string input;
            int inputToInt;
            do
            {
                Console.WriteLine("Select option: \n" +
                "1. Create a new league. \n" +
                "2. Add team to league \n" +
                "3. Remove team from league. \n" +
                "4. Add player to team \n" +
                "5. Remove player from team \n" +
                "6. Generate schedule \n" +
                "7. Quit");

                //input = Console.ReadLine();

                //inputToInt = Convert.ToInt32(input);


                inputToInt = getInt();

                executeSelection(inputToInt);

            } while (inputToInt != 7);

            return inputToInt;
        }

        static int getInt()
        {
            string input = Console.ReadLine();
            int inputToInt = int.Parse(input);
            return inputToInt;
        }
        
        static int getNumberOfTeams()
        {
            String strTeams;
            int nTeams = 0;
            Boolean valid = false;

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
            } while (!valid || nTeams < 1);

            return nTeams;
        }

        // create a new league and add to Leagues list
        static void addLeague()
          
        {
            Console.WriteLine("Enter league name: ");
            leagueName = Console.ReadLine();
            Console.WriteLine("Enter number of teams: ");
            int nTeams = getNumberOfTeams();
           
            League newLeague = new League(leagueName, nTeams);
            Leagues.Add(newLeague);
        }

        // Returns the league the user wants or null if that
        // league does not exist in the Leagues list
        static League getLeague()
        {
            League result = null;
            if (Leagues.Count > 0)
            {
                Console.WriteLine("Current leagues : \n");
                foreach (League league in Leagues)
                {
                    Console.Write(league.LeagueName + Environment.NewLine);
                }
                Console.WriteLine("Select a league from the above list");
                string readLeague = Console.ReadLine();
                int leagueCounter = 0;
              
                while (leagueCounter < Leagues.Count() &&
                    Leagues[leagueCounter].LeagueName != readLeague)
                {
                    ++leagueCounter;
                }

                if (leagueCounter < Leagues.Count)
                {
                    result = Leagues[leagueCounter];
                }
                else
                {
                    Console.WriteLine("The league does not exist!");
                }
            }
            else { Console.WriteLine("There are no leagues!"); }

            Console.WriteLine(Environment.NewLine);
            return result;
        }

        // Add new team to the league passed in
        static void addTeam(League league)
        {
            Console.WriteLine("Enter team name: ");
            string readTeam = Console.ReadLine();

            Team teamToAdd = new Team(readTeam, league);
            league.addTeam(teamToAdd);
        }

        // Remove team from the league passed in
        //static void removeTeam(League league)
        //{
        //    Team teamToRemove = getTeam(ref league);
        //    if (teamToRemove != null)
        //    {
        //        league.removeTeam(teamToRemove);
        //    }
        //}

        // Returns the team the user wants or null if that 
        // team does not exist in the league passed in 
        static void removeTeam(ref League league)
        {
           
            string readTeam;
            if (league != null && league.Teams.Count > 0)
            {
                int counter = 0;
                Console.WriteLine("Current teams : \n");
                foreach (Team team in league.Teams)
                {
                    Console.WriteLine(team.TeamName + "\n");
                }

                bool teamNameFound = false;
                do
                {
                    Console.WriteLine("Enter team name: ");
                    readTeam = Console.ReadLine();
                    while (counter < league.Teams.Count && teamNameFound == false)
                    //foreach(Team t in league.Teams)
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
        static Team getTeam(ref League league)
        {
            string readTeam;
            Team result = null;
            int counter = 0;
            if (league != null && league.Teams.Count > 0)
            {
                Console.WriteLine("Teams in league: ");
                foreach (Team team in league.Teams)
                {
                    Console.WriteLine(team.TeamName + "\n");
                }

                bool teamNameFound = false;
                do
                {
                    Console.WriteLine("Enter team name: ");
                    readTeam = Console.ReadLine();
                    while(counter < league.Teams.Count && teamNameFound == false)
                    {
                        if (league.Teams[counter].TeamName == readTeam)
                        {
                            teamNameFound = true;
                            result = league.Teams[counter];
                        }
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
        // Add a new player to the team passed in
        static void addPlayer( Team team)
        {

                string fName;
                string lName;
                Console.WriteLine("New player: "
                  + Environment.NewLine +  "First name: ");
                fName = Console.ReadLine();
                Console.WriteLine("Last name: ");
                lName = Console.ReadLine();

                Player newPlayer = new Player(lName, fName);
                team.addPlayer(newPlayer);
            
        }
        static void removePlayer(ref Team theTeam)
        {

            string readFirstName, readLastName;
            if (theTeam != null && theTeam.Players.Count > 0)
            {
                int counter = 0;
                Console.WriteLine("Current teams : \n");
                foreach (Player player in theTeam.Players)
                {
                    Console.WriteLine(player.FirstName + ", " + player.LastName + "\n");
                }

                bool playerNameFound = false;
                do
                {
                    Console.WriteLine("Enter first name: ");
                    readFirstName = Console.ReadLine();
                    while (counter < theTeam.Players.Count && playerNameFound == false)
                    //foreach(Team t in league.Teams)
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
        static void executeSelection(int input)
        {
            switch (input)
            {
                case 1:
                    addLeague();
                    break;
                case 2:
                    League leagueToAddTo = getLeague();
                    if (leagueToAddTo != null)      {
                        addTeam(leagueToAddTo);
                    }                 
                    break;
                case 3:
                    League leagueToRemoveFrom = getLeague();
                    if (leagueToRemoveFrom != null)
                    {
                        removeTeam(ref leagueToRemoveFrom);
                    }
                        
                    break;
                case 4:
                    League leagueToAddPlayer = getLeague();
                    if (leagueToAddPlayer != null)
                    {
                        Team theTeam = getTeam(ref leagueToAddPlayer);  
                        if(theTeam != null)
                        {
                            addPlayer(theTeam);
                        }
                    }
                    break;
                case 5:
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
                case 6:

                    break;
                case 7:
                    break;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }


        static void Main(string[] args)
        {
            const int QUIT = 7;
            int selection;
            do
            {
                selection = getSelection();
            } while (selection != QUIT);

        }
    }
}
