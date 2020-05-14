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

        string roomName;
        string description;

        public Location(string roomName)
        {
            characters = new Dictionary<string, Character>();
            connectedRooms = new Dictionary<string, Location>();
            items = new Dictionary<string, Item>();
            
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
