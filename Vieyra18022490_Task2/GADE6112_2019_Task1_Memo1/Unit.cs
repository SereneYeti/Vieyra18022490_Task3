﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vieyra18022490_Task2
{
    [Serializable]
    public abstract class Unit
    {   //Abstract class with no code implemented 
        //Used for the sake of re-use and inheritance        
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected int faction;
        protected string symbol;
        protected string name;
        protected bool isAttacking;
        

        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
        public abstract (Unit,int) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();
        //public abstract void Save();
        //public abstract void Read(List<Unit> u);
    }
}
