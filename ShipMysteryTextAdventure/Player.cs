using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Player
    {
        string name;
        Dictionary<int, Item> inventory;

        public Player()
        {
            inventory = new Dictionary<int, Item>();
        }

        public void AddItem(int i)
        {
            inventory.Add(i, Game.GetItem(i));
        }

        public void RemoveItem(int i)
        {
            inventory.Remove(i);
        }

        public bool HasItem(int i)
        {
            return inventory.ContainsKey(i);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
