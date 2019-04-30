// Author: Willertz, Ansari, Ranson
// Description: This class stores information about the games played to include
// the home team, away team, declares the winner of a game, and updates the team's 
// winning percentage.

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
            Home = team1;
            Away = team2;
            ScoreTeam1 = -1;
            ScoreTeam2 = -1;
        }

        public void setScore(string teamName, int score)
        {
            if (teamName == Home.TeamName)
            {
                ScoreTeam1 = score;
                // if team 2 score is set both are set and we can declare winner
                if(ScoreTeam2 >= 0)
                {
                    declareWinner();
                }
            }
            else if (teamName == Away.TeamName)
            {
                ScoreTeam2 = score;
                // if team 1 score is set both are set and we can declare winner
                if(ScoreTeam1 >= 0)
                {
                    declareWinner();
                }
            }
        }

        public void declareWinner()
        {
            if (ScoreTeam1 > ScoreTeam2)
            {
                Winner = Home.TeamName;
                Home.Record[0]++;
                Away.Record[1]++;
            }
            else if (ScoreTeam2 > ScoreTeam1)
            {
                Winner = Away.TeamName;
                Home.Record[1]++;
                Away.Record[0]++;
            }
            else
            {
                Winner = "TIE";
            }

            Home.updateWP();
            Away.updateWP();
        }

        public Team Home { set; get; }
        public Team Away { set; get; }

        public string Winner { set; get; }
        public int ScoreTeam1 { set; get; }
        public int ScoreTeam2 { set; get; }
    }
}
