using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Character
    {
        string name;
        int id;

        public Character(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetID()
        {
            return this.id;
        }
    }
}
