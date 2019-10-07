using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Vieyra18022490_Task2
{
    
    class ResourceBuilding : Building
    {   //Recourse Building Class, Inherits from Building class. Handles Resource Buildings
        //Variables Reflec Building class
        public bool Destroyed { get; set; }

        
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public int MaxHealth
        {
            get { return base.maxHealth; }
        }
           
        public int Faction
        {
            get { return base.faction; }
        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        string resourceType;
        int resourcesPerRound;
        int resourcesRemaining;
        int resourcesGenerated;

        public ResourceBuilding(int xxPos, int yyPos, int hHealth, int fFaction, string sSymbol, string rType, int rPerRound, int rRemaining)
        {   //Constructor
            XPos = xxPos;
            YPos = yyPos;
            Health = hHealth;
            faction = fFaction;
            Symbol = sSymbol;
            resourceType = rType;
            resourcesPerRound = rPerRound;
            resourcesRemaining = rRemaining;

        }
        public ResourceBuilding()
        { } //Constructor

        
        public override void Destruction()
        {   //Handles the destruction of resource buildings
            Destroyed = true;
            Symbol = "X";
        }

        public string GenerateResources(Timer tmr)
        {   //Handels the generation of resources
            string temp = "";
            if(tmr.Enabled == true)
            {                
                if (resourcesRemaining > 0)
                {
                    resourcesGenerated += resourcesPerRound;
                    resourcesRemaining -= resourcesPerRound;
                }
            }
            temp = "Resources per round: " + resourcesPerRound + "\nResources Generated: " + resourcesGenerated
                + "\nResources Remaining: " + resourcesRemaining;
            return temp;
        }

        public override string ToString()
        {   //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Building: ";
            temp += resourceType;
            temp += "{" + Symbol + "}";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health + ", Generated: " + resourcesGenerated + ", Generated per round: " + resourcesPerRound + ", Resources Remaining: " + resourcesRemaining;
            temp += (Destroyed ? " DESTROYED!" : " WORKING!");
            return temp;
        }

        //public override void Save()
        //{   
        //    Map map = new Map();
        //    List<Building> building = map.Buildings;
        //    //Saving to the DAT file
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream fs = new FileStream("resourceBuilding.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

        //    try
        //    {

               
        //            bf.Serialize(fs, building);
        //            fs.Close();
                

        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }

        //}

        //public override void Read(List<Building> b)
        //{
        //    //Reading from the DAT file
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream fs = new FileStream("resourceBuilding.dat", FileMode.Open, FileAccess.Read, FileShare.None);

        //    try
        //    {
        //        b = (List<Building>)bf.Deserialize(fs);
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}
    }
}
