using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Item
    {
        int id;
        string name;
        string description;
        List<Clue> clues;

        public Item(int id, string name, string description)
        {
            clues = new List<Clue>();

            this.description = description;
            this.id = id;
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
