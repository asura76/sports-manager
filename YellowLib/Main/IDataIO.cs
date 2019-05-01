using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Author: Willertz, Ansari, Ranson
// Description: This class is an interface for loading and saving data from 
// league.

using System.Threading.Tasks;
using LeagueGenLib;
using Main;


    public interface IDataIO
    {
        void saveData(string fileName);

        void loadData(string fileName);

    }

