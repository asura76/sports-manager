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
            
        
                int leagueCounter = 0;
               
               String fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (FileStream fileStream = new FileStream(fileName + "\\test.xml", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fileStream))
            using (XmlTextWriter xmlWriter = new XmlTextWriter(sw))
                
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Leagues");
                foreach (League theLeagues in Program.Leagues)
                {
                    xmlWriter.Indentation = 4;

                    xmlWriter.WriteElementString("LeagueName" + (leagueCounter + 1), theLeagues.LeagueName);
                    xmlWriter.WriteElementString("NumberToMakePlayoffs" + (leagueCounter + 1), theLeagues.NPlayoffTeams.ToString());
                    leagueCounter++;
                    writeTeams(xmlWriter, theLeagues);                    
                    settings.Indent = false;
                }
               //Writer.WriteEndElement();
                xmlWriter.Close();
            }

        }
        public void writeTeams(XmlTextWriter xmlWriter, League theLeagues)
        {
            int teamCounter = 0;
            if(theLeagues != null && theLeagues.Teams.Count > 0)
            {
                xmlWriter.WriteStartElement("Teams");
                foreach (Team theTeam in theLeagues.Teams)
                {
                    xmlWriter.WriteElementString("Team" + (teamCounter + 1), theTeam.TeamName);
                    teamCounter++;
                    writePlayers(xmlWriter, teamCounter, theTeam);

                }
                xmlWriter.WriteEndElement();
            }
          
        }
        public void writePlayers(XmlTextWriter xmlWriter, int teamCounter, Team theTeam)
        {
            int playerCounter = 0;
            if(theTeam != null && theTeam.Players.Count > 0)
            {
                xmlWriter.WriteStartElement("Players");
                foreach (Player thePlayer in theTeam.Players)
                {
                    xmlWriter.WriteElementString("Team" + (teamCounter + 1) + "Player" + (playerCounter + 1),
                    thePlayer.LastName + "," + thePlayer.FirstName);
                    playerCounter++;
                }
                xmlWriter.WriteEndElement();
            }
          
        }
    }
}
