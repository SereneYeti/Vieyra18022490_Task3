using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;


namespace Vieyra18022490_Task2
{
    
    public class RangedUnit : Unit
    {   //Ranged Unit class, Inherits from the Unit class
        //Variables reflect Unit class
        //isDead field used for Death method
        public bool IsDead { get; set; }
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
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

        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }
        
        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }

        public int Faction
        {
            get { return base.faction; }
        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol= value; }
        }

        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        public RangedUnit(int x, int y, int h, int s, int a, int ar, int f, string sy)
        {   //Constructor
            XPos = x;
            YPos = y;
            Health = h;
            base.maxHealth = h;
            Speed = s;
            Attack = a;
            AttackRange = ar;
            base.faction = f;
            Symbol = sy;
            IsAttacking = false;
            IsDead = false;
        }

        public RangedUnit()
        { } //Constructor
        public override void Death()
        {   //Handles the death of a ranged Unit
            symbol = "X";
            IsDead = true;
        }

        public override void Move(int dir)
        {   //Handles the movement of the units
            switch(dir)
            {
                case 0: YPos--;  break; //North
                case 1: XPos++; break; //East
                case 2: YPos++;  break; //South
                case 3: XPos--;  break; //West
                default: break;
            }
        }

        public void Pillage(Building building)
        {   //Damaging of the buidlings
            if (inRangeBulidngs(building))
            {
                if (building is ResourceBuilding)
                {
                    ((ResourceBuilding)building).Health = -Attack;

                    if (((ResourceBuilding)building).Health <= 0)
                    {
                        building.Destruction();
                    }
                }
                if (building is FactoryBuilding)
                {
                    ((FactoryBuilding)building).Health = -Attack;
                    if (((FactoryBuilding)building).Health <= 0)
                    {
                        building.Destruction();
                    }
                }
            }
        }

        public bool inRangeBulidngs(Building building)
        {
            int distance = 0;
            int otherX = 0;
            int otherY = 0;
            if (building is FactoryBuilding)
            {
                otherX = ((FactoryBuilding)building).XPos;
                otherY = ((FactoryBuilding)building).YPos;
            }
            else if (building is ResourceBuilding)
            {
                otherX = ((ResourceBuilding)building).XPos;
                otherY = ((ResourceBuilding)building).YPos;
            }

            distance = Math.Abs(XPos - otherX) + Math.Abs(YPos - otherY);
            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Combat(Unit attacker)
        {   //Handles the combat between two units
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.Attack - ru.AttackRange);
            }

            if(Health <= 0)
            {   //Confirms wheterh the attacked unit has any health remaining, if it doesn't the Death method is called
                Death(); //DEATH !!!
            }
        }

        public override bool InRange(Unit other)
        {   //Confrims if a unit is in range to attack
            int distance = 0;
            int otherX = 0;
            int otherY = 0;
            if (other is MeleeUnit)
            {
                otherX = ((MeleeUnit)other).XPos;
                otherY = ((MeleeUnit)other).YPos;
            }
            else if (other is RangedUnit)
            {
                otherX = ((RangedUnit)other).XPos;
                otherY = ((RangedUnit)other).YPos;
            }

            distance = Math.Abs(XPos - otherX) + Math.Abs(YPos - otherY);
            if(distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override (Unit, int) Closest(List<Unit> units)
        {   //Confirms the closest possilbe unit for attack
            int shortest = 100;
            Unit closest = this;
            //Closest Unit and Distance                    
            foreach (Unit u in units)
            {
                if (u is MeleeUnit)
                {
                    MeleeUnit otherMu = (MeleeUnit)u;
                    int distance = Math.Abs(this.XPos - otherMu.XPos)
                               + Math.Abs(this.YPos - otherMu.YPos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherMu;
                    }
                }
                else if (u is RangedUnit)
                {
                    RangedUnit otherRu = (RangedUnit)u;
                    int distance = Math.Abs(this.XPos - otherRu.XPos)
                               + Math.Abs(this.YPos - otherRu.YPos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherRu;
                    }
                }

            }
            return (closest, shortest);
        }

        public override string ToString()
        {   //Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Ranged: ";
            temp += Name;
            temp += "{" + Symbol + "}";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }

        //public override void Save()
        //{
        //        Map map = new Map();
        //        List<Unit> unit = map.Units;
        //        //Saving to the DAT file
        //        BinaryFormatter bf = new BinaryFormatter();
        //        FileStream fs = new FileStream("ranged.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

        //        try
        //        {
                    
        //                bf.Serialize(fs, unit);
        //                fs.Close();
                    
                   

        //        }
        //        catch (Exception ee)
        //        {
        //            MessageBox.Show(ee.Message);
        //        }
            
            

        //}
        //public override void Read(List<Unit> u)
        //{
        //    //Reading from the DAT file
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream fs = new FileStream("ranged.dat", FileMode.Open, FileAccess.Read, FileShare.None);

        //    try
        //    {
        //        u = (List<Unit>)bf.Deserialize(fs);
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}

    }
}
