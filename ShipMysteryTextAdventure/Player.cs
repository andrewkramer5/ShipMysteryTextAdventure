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
        Dictionary<string, Item> inventory;

        public Player()
        {
            inventory = new Dictionary<string, Item>();
        }

        public void AddItem(string name)
        {
            inventory.Add(name, Game.GetItem(name));
        }

        public void RemoveItem(string name)
        {
            inventory.Remove(name);
        }

        public bool HasItem(string name)
        {
            return inventory.ContainsKey(name);
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
