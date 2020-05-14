using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Item
    {
        string name;
        string description;
        List<Clue> clues;

        public Item(string name)
        {
            clues = new List<Clue>();
            
            this.name = name;
        }

        public void AddClue(Clue c)
        {
            clues.Add(c);
        }

        public string GetName()
        {
            return this.name;
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
