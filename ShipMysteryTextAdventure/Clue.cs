using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Clue
    {
        int value;
        string name;
        string description;
        List<Character> charConnections;

        public Clue(string name, int value)
        {
            this.name = name;
            this.value = value;
            this.charConnections = new List<Character>();
        }

        public int GetValue()
        {
            return this.value;
        }

        public string GetName()
        {
            return this.name;
        }

        public List<Character> GetCharConnections()
        {
            return this.charConnections;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public string getDescription()
        {
            return this.description;
        }
    }
}
