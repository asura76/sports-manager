// Author: Willertz, Ansari, Ranson
// Description: This class handles the loading of player names from a csv file
// that can be loaded into a team. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LeagueGenLib;

namespace Main
{
    public class CSVFileIO 
    {

        // Only used to read player names.
        public List<Player> loadPlayers(string fileName)
        {

            List<Player> playerList = new List<Player>();

            if (System.IO.File.Exists(fileName) == false)
            {
                Console.WriteLine("The file " + fileName + " does not exist!");
            }
            else
            {
                StreamReader sr = new StreamReader(fileName);
                string tmpStr;
                string[] splitString;
                String firstName, lastName;
                while (!sr.EndOfStream)
                {
                    tmpStr = sr.ReadLine();
                    splitString = tmpStr.Split(',');
                    if (splitString.Length > 0)
                    {
                        firstName = splitString[1];
                        lastName = splitString[0];
                        Player newPlayer = new Player(lastName, firstName);

                        playerList.Add(newPlayer);
                    }
                }
            }

            return playerList;

        }


    }
}
