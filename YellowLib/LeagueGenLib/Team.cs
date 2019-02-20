using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class Team
    {
        public Team(string teamName)
        {
            TeamName = teamName;
        }
        public string TeamName { private set; get; }


    }
}
