using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class Game
    {
        public Game(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        public Team Team1 { set; get; }
        public Team Team2 { set; get; }

        public int ScoreTeam1 { private set; get; }
        public int ScoreTeam2 { private set; get; }
    }
}
