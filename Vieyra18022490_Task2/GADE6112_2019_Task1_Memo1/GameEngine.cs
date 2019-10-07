using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vieyra18022490_Task2
{
    public class GameEngine
    {   //Class that deals with the processing of the in game logic and mechanics and implements everything.
        Map map = new Map();
        private int round;
        Random r = new Random();
        GroupBox grpMap;
        Timer tmr;
        Label resourcesLbl;
        int mapHeight, mapWidth;

        ResourceBuilding resourceBuilding = new ResourceBuilding(5, 5, 10, 0, "RB", "Gold", 10, 100);

        List<Unit> units = new List<Unit>();
        List<Building> buildings = new List<Building>();


        public int Round
        {
            get { return round; }
        }

       

        public GameEngine(int numUnits, TextBox txtInfo, GroupBox gMap, int numB, Timer timer, Label lbl, int mW, int mH)
        {   //Constructor
            grpMap = gMap;
            tmr = timer;
            resourcesLbl = lbl;
            mapWidth = mW;
            mapHeight = mH;
            map = new Map(numUnits, txtInfo,numB,mapWidth, mapHeight);
            map.setMap(grpMap);
            map.Generate();
            map.Display(grpMap);

            round = 1; 
        }

        public GameEngine(int mW, int mH,GroupBox gbxMap)
        {
            mapWidth = mW;
            mapHeight = mH;
            grpMap = gbxMap;
            map = new Map(mapHeight, mapWidth);
            map.setMap(grpMap);
        }

        public GameEngine()
        { } //Constructor

        public void Update()
        {   //Handling of all the ingame logic and processing occurs in this method.
            FactoryBuilding factoryBuilding = new FactoryBuilding(r.Next(0, 2), 2, 5, 5, 10, r.Next(0, 2), "FB");

            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25) // Running Away
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);

                        //Check In Range
                        if (distanceTo <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.XPos > closestMu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestMu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestMu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestMu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.XPos > closestRu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestRu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestRu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestRu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];
                   /* if (ru.Health <= ru.MaxHealth * 0.25) // Running Away is commented out to make for a more interesting battle - and some insta-deaths
                    {
                        ru.Move(r.Next(0, 4));
                    }
                    else
                    {*/
                        (Unit closest, int distanceTo) = ru.Closest(map.Units);
                      
                        //Check In Range
                        if (distanceTo <= ru.AttackRange)
                        {
                            ru.IsAttacking = true;
                            ru.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (ru.XPos > closestMu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestMu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestMu.YPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestMu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (ru.XPos > closestRu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestRu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestRu.YPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestRu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                        }

                  //  }

                }
            }
            
            map.Display(grpMap);
            round++;
            resourcesLbl.Text = resourceBuilding.GenerateResources(tmr);
        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            return distance;
        }

        public void Save()
        {
            //The save methods created in the map class are collected here to be called all together
            map.SaveUnits();
            map.SaveBuilding();
        }

        public void Read()
        {
            //The read methods created in the map class are collected here to be called all together
            units = map.ReadUnits();
            buildings = map.ReadBuildings();
        }

        public void DisplayAfterRead(GroupBox groupBox)
        {   //Handles re-desplaying of the previously saved information
            groupBox.Controls.Clear();

            foreach (Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.XPos * 20, mu.YPos * 20);
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
                else
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.XPos * 20, ru.YPos * 20);
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
                groupBox.Controls.Add(b);
            }

            foreach (Building b in buildings)
            {
                Button bl = new Button();
                if (b is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    bl.Size = new Size(30, 30);
                    bl.Location = new Point(rb.XPos * 20, rb.YPos * 20);
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
                    bl.Location = new Point(fb.XPos * 20, fb.YPos * 20);
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
                groupBox.Controls.Add(bl);
            }
        }

    }
}
