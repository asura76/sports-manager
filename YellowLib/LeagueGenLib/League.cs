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
        }

        public void addTeam(Team team)
        {
            Teams.Add(team);
        }

        public string LeagueName { private set; get; }

        public int MaxTeams { private set; get; }

        public List<Team> Teams { set; get; }
    }
}
