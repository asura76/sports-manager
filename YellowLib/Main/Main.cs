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

            Console.WriteLine("Current leagues : \n");
            foreach (League league in Leagues)
            {
                Console.Write(league.LeagueName + Environment.NewLine);
            }
            string readLeague = Console.ReadLine();
            int leagueCounter = 0;
            do
            {
                ++leagueCounter;
            }
            while (Leagues[leagueCounter].LeagueName != readLeague ||
            leagueCounter > Leagues.Count());

            if(leagueCounter <= Leagues.Count)
            {
                result = Leagues[leagueCounter];
            }

            return result;
        }

        // Add new team to the league passed in
        static void addTeam(League league)
        {
            Console.WriteLine("Enter team name: ");
            string readTeam = Console.ReadLine();

            Team teamToAdd = new Team(readTeam, league);
        }

        // Remove team from the league passed in
        static void removeTeam(League league)
        {
            Team teamToRemove = getTeam(league);
            if (teamToRemove != null)
            {
                league.removeTeam(teamToRemove);
            }
        }

        // Returns the team the user wants or null if that 
        // team does not exist in the league passed in 
        static Team getTeam(League league)
        {
            Team result = null;
            if (league != null)
            {
                Console.WriteLine("Enter team name: ");
                string readTeam = Console.ReadLine();
                foreach (Team team in league.Teams)
                {
                    Console.WriteLine(team.TeamName + "\n");
                }
                int teamCounter = 0;
                do
                {
                    ++teamCounter;
                }
                while (league.Teams[teamCounter].TeamName != readTeam ||
                teamCounter > league.Teams.Count());

                if (teamCounter <= league.Teams.Count)
                {
                    result = league.Teams[teamCounter];
                }
            }

            return result;
        }

        // Add a new player to the team passed in
        static void addPlayer(Team team)
        {
            if (team != null)
            {
                string fName;
                string lName;
                Console.WriteLine("New player: /n"
                    + "First name: ");
                fName = Console.ReadLine();
                Console.WriteLine("Last name: ");
                lName = Console.ReadLine();

                Player newPlayer = new Player(lName, fName);
                team.addPlayer(newPlayer);
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
                    League leagueToAddTo = getLeague();
                    if (leagueToAddTo != null)
                    {
                        addTeam(leagueToAddTo);
                    }
                    break;
                case 3:
                    League leagueToRemoveFrom = getLeague();
                    removeTeam(leagueToRemoveFrom);
                    break;
                case 4:
                    League league = getLeague();
                    if (league != null)
                    {
                        Team teamToAddTo = getTeam(league);
                        if (teamToAddTo != null)
                        {
                            addPlayer(teamToAddTo);
                        }
                    }
                    break;
                case 5:

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
