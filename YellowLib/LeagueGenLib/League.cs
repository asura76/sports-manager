using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class League
    {
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

        public string LeagueName { private set; get; }

        public int MaxTeams { private set; get; }

        public List<Team> Teams { set; get; }

        public List<Player> AllPlayersInLeague { set; get; }

        public Game[][] Schedule { set; get; }
        
    };
}

