using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Character
    {
        int id;
        string name;
        string description;

        public Character(int id, string name, string description)
        {
            this.description = description;
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

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public int GetID()
        {
            return this.id;
        }
    }
}
