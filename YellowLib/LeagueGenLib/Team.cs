// Author: Willertz, Ansari, Ranson
// Description: This class represents a team in a league as well as the team 
// ranking, winning percentage, record, the team name, and the players.
// It handles adding and removing players and updating the winning percentage.


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
        public bool containsPlayer(string fName, string lName)
        {
            bool playerFound = false;

            int counter = 0;
            while (playerFound == false && counter < Players.Count)
            {
                if (Players[counter].FirstName == fName)
                {
                    if (Players[counter].LastName == lName)
                    {
                        playerFound = true;
                    }
                }
                counter++;
            }

            return playerFound;
        }

        public void updateWP()
        {
            if (Record[0] == 0)
            {
                WinPercentage = 0;
            }
            else
            {
                double nGames = Record[0] + Record[1];

                WinPercentage = Record[0] / nGames;
            }

            MyLeague.updateRankings();
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

        public int Ranking { set; get; }
        public double WinPercentage { private set; get; }

    }
}
