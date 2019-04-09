using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using LeagueGenLib;
using Main;

namespace Main
{
    class SaveXML : ISaveData
    {
        //public List<League> Leagues = new List<League>();
        public void saveData()
        {
            
                int counter = 0;
                int playerCounter = 0;
                int leagueCounter = 0;
               
               String fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (FileStream fileStream = new FileStream(fileName + "\\test.xml", FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fileStream))
                using (XmlTextWriter xmlWriter = new XmlTextWriter(sw))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.Indentation = 4;
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Leagues");
                    foreach (League leaguesNames in Program.Leagues)
                    {
                        xmlWriter.WriteElementString("LeagueName" + leagueCounter + 1, leaguesNames.LeagueName);
                        xmlWriter.WriteElementString("NumberToMakePlayoffs" + leagueCounter + 1, leaguesNames.NPlayoffTeams.ToString());
                        counter = 0;
                        leagueCounter++;
                        foreach (Team theTeam in leaguesNames.Teams)
                        {
                            xmlWriter.WriteStartElement("Teams");
                            xmlWriter.WriteElementString("Team" + (counter + 1), theTeam.TeamName);
                            counter++;
                            playerCounter = 0;
                            foreach (Player thePlayer in theTeam.Players)
                            {
                                xmlWriter.WriteStartElement("Players");
                                xmlWriter.WriteElementString("Team" + (counter + 1) + "Player" + playerCounter + 1,
                                    thePlayer.LastName + "," + thePlayer.FirstName);
                                playerCounter++;
                            }
                            xmlWriter.WriteEndElement();
                        }
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }

        }
    }
}
