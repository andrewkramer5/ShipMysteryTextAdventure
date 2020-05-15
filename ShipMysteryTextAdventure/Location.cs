using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Location
    {
        Dictionary<string, Character> characters;
        Dictionary<string, Location> connectedRooms;
        Dictionary<string, Item> items;

        int id;
        string roomName;
        string description;

        public Location(int id, string roomName, string description)
        {
            characters = new Dictionary<string, Character>();
            connectedRooms = new Dictionary<string, Location>();
            items = new Dictionary<string, Item>();

            this.description = description;
            this.id = id;
            this.roomName = roomName;
        }

        public Dictionary<string, Character> GetCharacters()
        {
            return this.characters;
        }

        public Dictionary<string, Location> GetConnectedRooms()
        {
            return this.connectedRooms;
        }

        public Dictionary<string, Item> GetItems()
        {
            return this.items;
        }

        public string GetName()
        {
            return this.roomName;
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
