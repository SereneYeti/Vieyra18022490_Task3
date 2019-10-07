using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Vieyra18022490_Task2
{
    [Serializable]
    public class Map
    {   //Class that deals with the game map and the generation of units and buildings
        List<Unit> units;
        List<Building> buildings;
        Random r = new Random();
        int numUnits = 0;
        TextBox txtInfo;
        int numBuildings;
        int mapWidth, mapHeight;
        
        

        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public Map(int n, TextBox txt, int nb, int mW, int mH)
        {   //Constructor
            units = new List<Unit>();
            buildings = new List<Building>();
            numUnits = n;
            txtInfo = txt;
            numBuildings = nb;
            mapWidth = mW;
            mapHeight = mH;
        }

        public Map(int mW, int mH)
        {
            mapWidth = mW;
            mapHeight = mH;
        }

        public Map()
        { } //Constructor

        public void setMap(GroupBox grpMap)
        {
            grpMap.Height = mapHeight;
            grpMap.Width = mapWidth;
        }
        
        public void Generate()
        {   //Method that generates units and buildings                      
            
            for(int i = 0; i < numUnits; i++)
            {
               if(r.Next(0,3) == 0) //Generate Melee Unit
                {
                    MeleeUnit m = new MeleeUnit(r.Next(0, mapWidth),
                                                r.Next(0, mapHeight),
                                                100,
                                                1,
                                                20,
                                                (i % 2 == 0 ? 1 : 0),
                                                "M");
                    units.Add(m);
                }
               else if((r.Next(0, 3) == 1)) // Generate Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(r.Next(0, mapWidth),
                                                r.Next(0, mapHeight),
                                                100,
                                                1,
                                                20,
                                                5,
                                                (i % 2 == 0 ? 1 : 0),
                                                "R");
                    units.Add(ru);
                }
               else
                {
                    WizzardUnits wu = new WizzardUnits("Wizzard",
                                                    r.Next(0, mapWidth),
                                                    r.Next(0, mapHeight),
                                                    10,
                                                    10,
                                                    1,
                                                    2,
                                                    (i % 2 == 0 ? 1 : 0),
                                                    "W");
                    units.Add(wu);
                }
               
            }

            for(int z = 0; z <numUnits/2;z++)
            {
                WizzardUnits wu = new WizzardUnits("Wizzard",
                                                    r.Next(0, mapWidth),
                                                    r.Next(0, mapHeight),
                                                    10,
                                                    10,
                                                    1,
                                                    2,
                                                    2,
                                                    "W");
                units.Add(wu);
            }

            for(int x = 0; x < numBuildings; x++)
            {
                if (r.Next(0, 2) == 0)
                {
                    ResourceBuilding rb = new ResourceBuilding(r.Next(0,20), r.Next(0, 20), 10, 0, "RB", "Gold", 10, 100);
                    FactoryBuilding fb = new FactoryBuilding(r.Next(0, 2), 2, r.Next(0, 20), r.Next(0, 20), 10, r.Next(0, 2), "FB");

                    buildings.Add(rb);
                   buildings.Add(fb);
                }
                else
                {
                    ResourceBuilding rb = new ResourceBuilding(r.Next(0, 20), r.Next(0, 20), 10, 0, "RB", "Gold", 10, 100);
                    FactoryBuilding fb = new FactoryBuilding(r.Next(0, 2), 2, r.Next(0, 20), r.Next(0, 20), 10, r.Next(0, 2), "FB");

                    buildings.Add(rb);
                   buildings.Add(fb);
                }
            }
        }

        public void Display(GroupBox groupBox)
        {   //Handles the display of the game map
            groupBox.Controls.Clear();
            foreach(Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.XPos * mapWidth, mu.YPos * mapHeight);
                    b.Text = mu.Symbol;
                    if (mu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                else if(u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.XPos * mapWidth, ru.YPos * mapHeight);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                else if(u is WizzardUnits)
                {
                    WizzardUnits wu = (WizzardUnits)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(wu.XPos * mapWidth, wu.YPos * mapHeight);
                    b.Text = wu.Symbol;
                    if (wu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else if(wu.Faction == 1)
                    {
                        b.ForeColor = Color.Green;
                    }
                    else if(wu.Faction == 2)
                    {
                        b.ForeColor = Color.DarkViolet;
                    }
                }
                b.Click += Unit_Click;
                groupBox.Controls.Add(b);
            }

            foreach (Building b in buildings)
            {
                Button bl = new Button();
                if (b is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    bl.Size = new Size(30, 30);
                    bl.Location = new Point(rb.XPos * mapWidth, rb.YPos * mapHeight);
                    bl.Text = rb.Symbol;
                    if (rb.Faction == 0)
                    {
                        bl.ForeColor = Color.Red;
                    }
                    else
                    {
                        bl.ForeColor = Color.Green;
                    }
                }
                else
                {
                    FactoryBuilding fb = (FactoryBuilding)b;
                    bl.Size = new Size(30, 30);
                    bl.Location = new Point(fb.XPos * mapWidth, fb.YPos * mapHeight);
                    bl.Text = fb.Symbol;
                    if (fb.Faction == 0)
                    {
                        bl.ForeColor = Color.Red;
                    }
                    else
                    {
                        bl.ForeColor = Color.Green;
                    }
                }
                bl.Click += Building_Click;
                groupBox.Controls.Add(bl);
            }
        }

        public void Building_Click(object sender, EventArgs e)
        {   //Handles what happens when you click on a building
            int x, y;
            Button btn = (Button)sender;
            x = btn.Location.X / 20;
            y = btn.Location.Y / 20;

            foreach( Building b in buildings)
            {
                if(b is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    txtInfo.Text = "";
                    txtInfo.Text = rb.ToString();
                }
                else if (b is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)b;
                    txtInfo.Text = "";
                    txtInfo.Text = fb.ToString();
                    if(fb.UnitType == 0)//Melee
                    {
                        MeleeUnit mu = new MeleeUnit(fb.XPos, fb.YPos, 20, 1, 5, fb.Faction, "M");
                        Button button = new Button();
                        button.Size = new Size(20, 20);
                        button.Location = new Point(fb.XPos+1 * 20, fb.YPos+1 * 20);
                        button.Text = mu.Symbol;

                            
                    }
                    else
                    {
                        RangedUnit ru = new RangedUnit(fb.XPos, fb.YPos, 20, 1, 5,5, fb.Faction, "R");
                        Button button = new Button();
                        button.Size = new Size(20, 20);
                        button.Location = new Point(fb.XPos+1 * 20, fb.YPos+1 * 20);
                        button.Text = ru.Symbol;
                        
                    }
                    

                }
            }
        }

        public void Unit_Click(object sender, EventArgs e)
        {   //Handles what happens when you click on a unit
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach(Unit u in units)
            {
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.XPos == x && ru.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.XPos == x && mu.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
            }
        }

        public void SaveUnits()
        {   //Handes the saving of Units
            
            //Saving to the DAT file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("units.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            try
            {

                bf.Serialize(fs, (List<Unit>)units);
                fs.Close();



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public  List<Unit> ReadUnits()
        {   //Handles the reading of files to re-generate the previously saved units
            //Reading from the DAT file
            List<Unit> temp = new List<Unit>();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("units.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                temp = (List<Unit>)bf.Deserialize(fs);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return temp;
        }

        public void SaveBuilding()
        {   //Handles the saving of Buildings

            //Saving to the DAT file

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("buildings.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            try
            {


                bf.Serialize(fs, (List<Building>)buildings);
                fs.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        public List<Building> ReadBuildings()
        {   //Handles the reading of files to re-generate the previously saved buildings
            //Reading from the DAT file
            List<Building> temp = new List<Building>();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("buildings.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                temp = (List<Building>)bf.Deserialize(fs);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return temp;
        }



    }
}
