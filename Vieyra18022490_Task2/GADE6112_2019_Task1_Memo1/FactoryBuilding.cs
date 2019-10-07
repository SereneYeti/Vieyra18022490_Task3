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
    
    class FactoryBuilding : Building
    {
        public bool Destroyed { get; set; }

        private int unitType;//0 for Melee 1 for Ranged

        public int UnitType
        {
            get { return unitType; }
        }

        private int productionSpeed;

        public int ProductionSpeed
        {
            get { return productionSpeed; }
        }
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

        public override void Destruction()
        {
            Destroyed = true;
            Symbol = "X";
        }
        public FactoryBuilding(int uType, int prodSpeed, int xxpos, int yypos, int hhealth, int ffaction, string ssymbol)
        {
            unitType = uType;
            productionSpeed = prodSpeed;
            XPos = xxpos;
            YPos = yypos;
            Health = hhealth;
            faction = ffaction;
            Symbol = ssymbol;
        }
        public FactoryBuilding()
        { }

        public Unit SpawnUnit()
        {
            if(Faction == 0)
            {
                if (unitType == 0) //Melee Unit
                {
                    MeleeUnit mu = new MeleeUnit(XPos, YPos, health, 1,20,0,"M");
                    return mu;
                }
                else //Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(XPos, YPos, health, 1, 20,5, 0, "R");
                    return ru;
                }
            }
            else
            {
                if (unitType == 0) //Melee Unit
                {
                    MeleeUnit mu = new MeleeUnit(XPos, YPos, health, 1, 20, 1, "M");
                    return mu;
                }
                else //Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(XPos, YPos, health, 1, 20, 5, 0, "R");
                    return ru;
                }
            }
            
        }
        

        public override string ToString()
        {
            string temp = "";
            temp += "Building: ";
            if(unitType == 0) { temp += "Melee Units"; } else { temp += "Ranged Units"; }
            temp += "{" + Symbol + "}";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health + ", Production Speed: " + ProductionSpeed;
            temp += (Destroyed ? " DESTROYED!" : " WORKING!");
            return temp;
        }

        //public override void Save()
        //{
        //    Map map = new Map();
        //    List<Building> building = map.Buildings;
        //    //Saving to the DAT file
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream fs = new FileStream("factoryBuilding.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

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
        //    FileStream fs = new FileStream("factoryBuilding.dat", FileMode.Open, FileAccess.Read, FileShare.None);

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
