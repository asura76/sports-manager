using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class League
    {
        const int MIN_TEAMS_FOR_SCHEDULING = 4;
        public League(string leagueName, int maxTeams = 0)
        {
            LeagueName = leagueName;
            MaxTeams = maxTeams;
            Teams = new List<Team>();
            AllPlayersInLeague = new List<Player>();
        }

        // possibly add error message to tell user
        // the team failed to add because the league is full
        public void addTeam(Team team)
        {
            if (Teams.Count < MaxTeams)
            {
                Teams.Add(team);
            }

        }
        public void removeTeam(Team teamToRemove)
        {
            if (Teams.Contains(teamToRemove))
            {
                Teams.Remove(teamToRemove);
            }
        }

        public void addGameToSchedule(Game newGame)
        {
            //Schedule.Add(newGame);
        }

        public void generateSchedule(int nWeeks)
        {
            int nTeams = Teams.Count;
            int nGames = nTeams / 2;
            Schedule = new Game[nWeeks][];
            for (int i = 0; i < nWeeks; i++)
            {
                Schedule[i] = new Game[nGames];
                int first = 0;
                int last = nTeams-1;
                for (int j = 0; j < nGames; j++)
                {
                    Game newGame = new Game(Teams[first], Teams[last]);
                    first++;
                    last--;
                }


            }
            
        }
        public void makeTeamsEven(List<Team> theTeams)
        {
            if (theTeams.Count % 2 != 0)
            {
                Team item = new Team("BYE", this);

                theTeams.Add(item);
            }

        }
        public void moveItemAtIndexToFront<Team>(List<Team> theList, int size)
        {
            Team item = theList[size];
            theList.RemoveAt(size);
            theList.Insert(1, item);

        }
        public Game[,] generateSchedule(int nWeeks, List<Team> teams)
        {
            int nTeams = teams.Count;
            int nGames = (nWeeks / 2);
            // nWeeks - 1 as going to "weeks" will produce a dulicate of the first week (week 0).
            Game[,] Schedule = new Game[nWeeks - 1, nGames];
            // We need at least 4 teams to make the schedule work.
            if (nTeams >= MIN_TEAMS_FOR_SCHEDULING)
            {
                // There has to be an even number of teams. Add a bye if not..
                makeTeamsEven(teams);

                int last = nTeams;
                for (int i = 0; i < nWeeks - 1; i++)
                {
                    last = nTeams;
                    Game tmpGame;
                    for (int j = 0; j < nGames; j++)
                    {
                        tmpGame = new Game(teams.ElementAt(j), teams.ElementAt(last - 1));
                        Schedule[i, j] = tmpGame;
                        last--;
                        Console.WriteLine(Schedule[i, j].Team1.TeamName + " vs " + Schedule[i, j].Team2.TeamName);
                    }

                    moveItemAtIndexToFront(teams, nTeams - 1);
                }
            }

            return Schedule;

        }
        public string LeagueName { private set; get; }

        public int MaxTeams { private set; get; }

        public List<Team> Teams { set; get; }

        public List<Player> AllPlayersInLeague { set; get; }

        public Game[][] Schedule { set; get; }
        
    };
}

