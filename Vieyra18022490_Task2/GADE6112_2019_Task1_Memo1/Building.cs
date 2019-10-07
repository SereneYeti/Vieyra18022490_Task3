using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vieyra18022490_Task2
{
    [Serializable]
    public abstract class Building
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int faction;
        protected string symbol;

        public abstract void Destruction();
        public abstract override string ToString();
        //public abstract void Save();
        //public abstract void Read(List<Building> b);

    }
}
