using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGenLib
{
    public class Player
    {
        public Player(string lName, string fName)
        {
            LastName = lName;
            FirstName = fName;
        }

        // possible team data member

        public string FirstName { private set; get; }
        public string LastName { private set; get; }

    }

  
}
