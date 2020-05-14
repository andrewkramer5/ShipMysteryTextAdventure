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
        List<Clue> clues;

        public Item(int id, string name)
        {
            clues = new List<Clue>();

            this.id = id;
            this.name = name;
        }

        public void AddClue(Clue c)
        {
            clues.Add(c);
        }

        public int GetID()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
