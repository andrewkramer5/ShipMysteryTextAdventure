using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Location
    {
        Dictionary<int, Character> characters;
        Dictionary<int, Location> connectedRooms;

        int id;
        string roomName;
        string description;

        public Location(int id, string roomName)
        {
            characters = new Dictionary<int, Character>();
            connectedRooms = new Dictionary<int, Location>();

            this.id = id;
            this.roomName = roomName;
        }

        public bool AddCharacter(int c)
        {
            if (!this.characters.ContainsKey(c))
            {
                this.characters.Add(c, Game.GetCharacter(c));
                return true;
            }

            return false;
        }

        public bool RemoveCharacter(int c)
        {
            return this.characters.Remove(c);
        }

        public bool MoveCharacter(int c, int l)
        {
            if (this.characters.ContainsKey(c) && Game.GetLocation(l).GetCharacters().ContainsKey(l))
            {
                this.characters.Remove(c);
                Game.GetLocation(l).AddCharacter(c);
                return true;
            }

            return false;
        }

        public Dictionary<int, Character> GetCharacters()
        {
            return this.characters;
        }

        public Dictionary<int, Location> GetConnectedRooms()
        {
            return this.connectedRooms;
        }

        public int GetID()
        {
            return this.id;
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
