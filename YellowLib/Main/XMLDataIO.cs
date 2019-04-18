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
    public class XMLDataIO : IDataIO
    {
        //public List<League> Leagues = new List<League>();
        public void saveData(string fileName)
        {
                int leagueCounter = 0;
               
               String directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (FileStream fileStream = new FileStream(directory + "\\" + fileName, FileMode.Create))
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
                    writePlayers(xmlWriter, teamCounter, theTeam);
                    teamCounter++;
                }
                xmlWriter.WriteEndElement();
            }
          
        }
        public void writePlayers(XmlTextWriter xmlWriter, int teamCounter, Team theTeam)
        {
            int playerCounter = 0;
            if(theTeam != null && theTeam.Players.Count > 0)
            {
                //xmlWriter.Indentation = 0;
                //xmlWriter.WriteStartElement("Players");
                foreach (Player thePlayer in theTeam.Players)
                {
                    xmlWriter.WriteElementString("Team" + (teamCounter + 1) + "Player" + (playerCounter + 1),
                    thePlayer.LastName + "," + thePlayer.FirstName);
                    playerCounter++;
                }
                //xmlWriter.WriteEndElement();
            }
          
        }

        public void loadData(string fileName)
        {
            int leagueCtr = 1, teamCtr = 1, playerCtr = 1; 
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.IgnoreWhitespace = true;
            //using (XmlReader textReader = XmlReader.Create(fileName, settings))
            XmlTextReader textReader = new XmlTextReader(fileName);
           string leagueName = "";
         
            Team currTeam = null;
            while (textReader.Read())
            {
              
                XmlNodeType nType = textReader.NodeType;
                // if node type is an element  
                if (nType == XmlNodeType.Element)
                {
                    if (textReader.Name.ToString() == "LeagueName" + leagueCtr)
                    {
                        leagueName = textReader.ReadInnerXml();
                    }
                    if (textReader.Name.ToString() == "NumberToMakePlayoffs" + 
                        leagueCtr)
                    {
                        int numPTeams = Int32.Parse(textReader.ReadInnerXml());
                        Main.Program.addLeagueForTest(leagueName, numPTeams);
                        ++leagueCtr;
                    }
                    if (textReader.Name.ToString() == "Team" + teamCtr)
                    {  
                        League leagueToAddTeam = Main.Program.getLeagueForTest(leagueName);
                        currTeam = Main.Program.addAndGetTeamForTest
                            (leagueToAddTeam, textReader.ReadInnerXml());                        
                        teamCtr++;
                        playerCtr = 1;
                    }
                    if (textReader.Name.ToString() == "Team" + (teamCtr - 1) +
                      "Player" + playerCtr)
                    {
                        League leagueToAddPlayer = Main.Program.getLeagueForTest(leagueName);
                        string pFullName = textReader.ReadInnerXml();

                        string[] splitString = pFullName.Split(',');
                        string fname = splitString[1];
                        string lname = splitString[0];
                       
                        Main.Program.addPlayerForTest(ref currTeam, fname, lname);
                        ++playerCtr;
                       
                    }
                    
                }

            }
        }
    }
}
