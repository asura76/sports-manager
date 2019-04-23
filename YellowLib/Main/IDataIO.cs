using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueGenLib;
using Main;


    public interface IDataIO
    {
        void saveData(string fileName);

        void loadData(string fileName);
    List<Player> loadPlayers(string fileName);
    }

