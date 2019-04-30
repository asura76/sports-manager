// Author: Willertz, Ansari, Ranson
// Description: This class handles functions that pertain to a league.
// This includes a list of teams, players, number of teams to make the playoffs,
// number of weeks in a season, and the league schedule which includes
// functionality to add or remove teams, players, etc. from the league.

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
        public League(string leagueName, int nPlayoffTeams)
        {
            LeagueName = leagueName;
            NPlayoffTeams = nPlayoffTeams;
            Teams = new List<Team>();
            AllPlayersInLeague = new List<Player>();
            Rankings = new List<Team>();
        }

        public void addTeam(Team team)
        {
            Teams.Add(team);
        }
        public void removeTeam(Team teamToRemove)
        {
            if (Teams.Contains(teamToRemove))
            {
                Teams.Remove(teamToRemove);
            }
        }

        public bool containsTeam(string teamName)
        {
            bool teamFound = false;

            int counter = 0;
            while (teamFound == false && counter < Teams.Count)
            {
                if (Teams[counter].TeamName == teamName)
                {
                    teamFound = true;
                }
                counter++;
            }

            return teamFound;
        }


        public void makeTeamsEven(List<Team> theTeams)
        {
            if (theTeams.Count % 2 != 0)
            {
                Team item = new Team("BYE", this);

                theTeams.Add(item);
            }

        }
        public void moveItemAtEndToFront<Team>(List<Team> theList, int nGames)
        {
            const int INSERT_POSITION = 1;
            if (theList != null && nGames >= INSERT_POSITION + 1 &&
                theList.Count > nGames)
            {
                Team item = theList[nGames];
                theList.RemoveAt(nGames);
                theList.Insert(INSERT_POSITION, item);
            }

        }
        public void printScheduleByWeek(int week)
        {
            if (Schedule.GetLength(0) > 0)
            {

                Console.WriteLine("Week " + (week + 1) + "\n Home: ");
                for (int j = 0; j < Schedule.GetLength(1); j++)
                {
                    Console.WriteLine(Schedule[week, j].Home.TeamName + " vs Away: " + Schedule[week, j].Away.TeamName);
                }

                Console.WriteLine("\n");
            }
            else { Console.WriteLine("No schedule exists!"); }
        }
        public void printSchedule()
        {
            if (Schedule.GetLength(0) > 0)
            {
                for (int i = 0; i < Schedule.GetLength(0); i++)
                {
                    Console.WriteLine("Week " + (i + 1));
                    for (int j = 0; j < Schedule.GetLength(1); j++)
                    {
                        Console.WriteLine(Schedule[i, j].Home.TeamName + " vs " + Schedule[i, j].Away.TeamName);
                    }
                }
                Console.WriteLine("\n");
            }
            else { Console.WriteLine("No schedule exists!"); }
        }
        public Game[,] generateSchedule(int nWeeks, List<Team> teams)
        {
            int nTeams = teams.Count;
            int nGames = nTeams / 2;
            NWeeks = nWeeks;
            // nWeeks - 1 as going to "weeks" will produce a duplicate of the first week (week 0).
            Schedule = new Game[nWeeks, nGames];
            // We need at least 4 teams to make the schedule work.
            if (nTeams >= MIN_TEAMS_FOR_SCHEDULING)
            {
                // There has to be an even number of teams. Add a bye if not..
                makeTeamsEven(teams);
                // Recalculate in case there were an odd number of teams.
                nGames = nTeams / 2;
                int last = nTeams;

                for (int i = 0; i < nWeeks; i++)
                {
                    last = nTeams;
                    Game tmpGame;
                    for (int j = 0; j < nGames; j++)
                    {
                        tmpGame = new Game(teams.ElementAt(j), teams.ElementAt(last - 1));
                        Schedule[i, j] = tmpGame;
                        last--;
                    }

                    moveItemAtEndToFront(teams, nTeams - 1);
                }
            }


            return Schedule;

        }

        public void updateRankings()
        {
            List<Team> tempTeams = new List<Team>();
            foreach(Team t in Teams)
            {
                tempTeams.Add(t);
            }
            int rank = 1;
            while (Rankings.Count != Teams.Count)
            {
                int highestWP = 0;
                for(int i = 0; i < tempTeams.Count; i++)
                {
                    if (tempTeams[i].WinPercentage > tempTeams[highestWP].WinPercentage)
                    {
                        highestWP = i;
                    }
                }

                Rankings.Add(tempTeams[highestWP]);
                Rankings[rank - 1].Ranking = rank;
                tempTeams.RemoveAt(highestWP);
                rank++;
            }
            
        }

        public int NWeeks { get; private set; }

        public List<Team> Rankings;

        public string LeagueName { private set; get; }

        public int NPlayoffTeams { private set; get; }

        public List<Team> Teams { set; get; }

        public List<Player> AllPlayersInLeague { set; get; }

        public Game[,] Schedule { set; get; }

    };
}

