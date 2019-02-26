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
            Schedule = new List<Game>();
        }

        // possibly add error message to tell user
        // the team failed to add because the league is full
        public void addTeam(Team team)
        {
            if(Teams.Count < MaxTeams)
            {
                Teams.Add(team);
            }
                  
        }
        public void removeTeam(Team teamToRemove)
        {
            if(Teams.Contains(teamToRemove))
            {
                Teams.Remove(teamToRemove);
            }
        }

        public void addGameToSchedule(Game newGame)
        {
            Schedule.Add(newGame);
        }
        public void generateSchedule(int nGames)
        {
            //see how many teams we have
            //2 for loop??

        }

        public string LeagueName { private set; get; }

        public int MaxTeams { private set; get; }

        public List<Team> Teams { set; get; }

        public List<Player> AllPlayersInLeague { set; get; }

        public List<Game> Schedule { set; get; }
        
    }
}
