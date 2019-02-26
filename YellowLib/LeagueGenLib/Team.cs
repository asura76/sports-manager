using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class Team
    {
        public Team(string teamName, League myLeague)
        {
            TeamName = teamName;
            MyLeague = myLeague;

            Players = new List<Player>();
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


        public string TeamName { private set; get; }

        public League MyLeague { private set; get; } // league my team is in

        public List<Player> Players { set; get; }

        // going to need some sort of record data member as well
    }
}
