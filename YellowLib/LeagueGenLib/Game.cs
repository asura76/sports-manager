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
            ScoreTeam1 = -1;
            ScoreTeam2 = -1;
        }

        public void setScore(string teamName, int score)
        {
            if (teamName == Team1.TeamName)
            {
                ScoreTeam1 = score;
                // if team 2 score is set both are set and we can declare winner
                if(ScoreTeam2 >= 0)
                {
                    declareWinner();
                }
            }
            else if (teamName == Team2.TeamName)
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
                Winner = Team1.TeamName;
            }
            else if (ScoreTeam2 > ScoreTeam1)
            {
                Winner = Team2.TeamName;
            }
            else
            {
                Winner = "TIE";
            }
        }

        public Team Team1 { set; get; }
        public Team Team2 { set; get; }

        public string Winner { set; get; }
        public int ScoreTeam1 { private set; get; }
        public int ScoreTeam2 { private set; get; }
    }
}
