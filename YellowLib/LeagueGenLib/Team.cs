using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class Team
    {
        public const int N_RECORD = 2;

        public Team(string teamName, League myLeague)
        {
            TeamName = teamName;
            MyLeague = myLeague;

            Players = new List<Player>();

            // 2 integer array where first number is wins and second number is losses
            Record = new int[N_RECORD] {0, 0};
        }

        public void addPlayer(Player newPlayer)
        {
            if (!MyLeague.AllPlayersInLeague.Contains(newPlayer))
            {
                Players.Add(newPlayer);
                MyLeague.AllPlayersInLeague.Add(newPlayer);
            }
        }

        public void removePlayer(Player playerToRemove)
        {
            if (Players.Contains(playerToRemove))
            {
                Players.Remove(playerToRemove);
                MyLeague.AllPlayersInLeague.Remove(playerToRemove);
            }
        }
        public Boolean equals(Team otherTeam)
        {
            this.MyLeague.Equals(otherTeam.MyLeague);
            return string.Equals(this.TeamName, otherTeam.TeamName) &&
                string.Equals(MyLeague.LeagueName, otherTeam.MyLeague.LeagueName);
        }

        public string TeamName { private set; get; }

        public League MyLeague { private set; get; } // league my team is in

        public List<Player> Players { set; get; }

        public int[] Record { private set; get; }

    }
}
