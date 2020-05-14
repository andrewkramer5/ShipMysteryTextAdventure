using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    class Clue
    {
        private int value;
        private string name;
        private int charConnection;

        public Clue(string name, int value, int charConnection)
        {
            this.name = name;
            this.value = value;
            this.charConnection = charConnection;
        }

        public int GetValue()
        {
            return this.value;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetCharConnection()
        {
            return this.charConnection;
        }
    }
}
