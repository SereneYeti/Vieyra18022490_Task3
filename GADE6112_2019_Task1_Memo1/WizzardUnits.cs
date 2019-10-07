using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vieyra18022490_Task2
{
    class WizzardUnits : Unit
    {
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
            set { base.symbol = value; }
        }

        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        public WizzardUnits(string _Name, int _xPos, int _yPos, int _Health, int _MaxHealth, int _Attack, int _Speed, int _Faction
           , string _Symbol)
        {
            XPos = _xPos;
            YPos = _yPos;
            Health = _Health;
            maxHealth = _MaxHealth;
            Attack = _Attack;
            AttackRange = 1;
            Speed = _Speed;
            faction = _Faction;
            Symbol = _Symbol;
            IsAttacking = false;
        }
        public override (Unit, int) Closest(List<Unit> units)
        {
            //Finds the closes unit around for combat
            int shortest = 100;
            Unit closest = this;
            //Closest Unit and Distance                    
            foreach (Unit u in units)
            {
                if (u is MeleeUnit && u != this)
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
                else if (u is RangedUnit && u != this)
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

        public override void Combat(Unit attacker)
        {
            if(health >= MaxHealth/2)
            {   //Ensure the wizzard can only attack at 50% health or higher
                //Handles the combat between two units
                if (attacker is MeleeUnit)
                {
                    Health = Health - ((MeleeUnit)attacker).Attack;
                }
                else if (attacker is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)attacker;
                    Health = Health - (ru.Attack - ru.AttackRange);
                }

                if (Health <= 0)
                {   //Confirms wheterh the attacked unit has any health remaining, if it doesn't the Death method is called
                    Death(); //DEATH !!!
                }
            }
            
        }

        public override void Death()
        {
            //Handles the death of a ranged Unit
            symbol = "X";
            IsDead = true;
        }

        public override bool InRange(Unit other)
        {//Confrims if a unit is in range to attack
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
            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(int dir)
        {
            //Handles the movement of the units
            switch (dir)
            {
                case 0: YPos--; break; //North
                case 1: XPos++; break; //East
                case 2: YPos++; break; //South
                case 3: XPos--; break; //West
                default: break;
            }
        }

        public override string ToString()
        {//Override of the ToString Funciton in order to return the required string output when needed with ease.
            string temp = "";
            temp += "Wizzard: ";
            temp += Name;
            temp += "{" + Symbol + "}";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }
    }
}
