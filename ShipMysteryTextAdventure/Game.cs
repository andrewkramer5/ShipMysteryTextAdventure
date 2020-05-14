using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMysteryTextAdventure
{
    static class Game
    {
        //__________________
        //        IDs
        //__________________

        //Locations
        public const int ROOM_NAVIGATION = 0;
        public const int MAX_ROOM = 0;

        //Characters
        public const int MAX_CHAR = 0;

        //Items
        public const int MAX_ITEM = 0;

        //Commands
        public const int CMD_HELP = 0;
        public const int CMD_QUIT = 1;
        public const int MAX_CMD = 1;
        

        public static Dictionary<int, Location> rooms;
        public static Dictionary<int, Character> characters;
        public static Dictionary<int, Item> items;
        public static Dictionary<int, string> commands;
        public static Dictionary<string, int> commandIDs;
        public static Dictionary<int, string> cmdDescriptions;
        public static Player player;

        public static Location currentRoom;
        public static bool gameRunning;

        public static void Initialize()
        {
            rooms = new Dictionary<int, Location>();
            characters = new Dictionary<int, Character>();
            items = new Dictionary<int, Item>();
            commandIDs = new Dictionary<string, int>();
            commands = new Dictionary<int, string>();
            cmdDescriptions = new Dictionary<int, string>();
            player = new Player();

            //Locations

            //Characters

            //Items

            //Commands
            commandIDs.Add("help", Game.CMD_HELP);
            commands.Add(Game.CMD_HELP, "help");
            cmdDescriptions.Add(Game.CMD_HELP, "Lists all commands and descriptions");
            commandIDs.Add("quit", Game.CMD_QUIT);
            commands.Add(Game.CMD_QUIT, "quit");
            cmdDescriptions.Add(Game.CMD_QUIT, "Quits the game");
        }

        public static void Start()
        {
            gameRunning = true;
            bool runClear = true;

            while (gameRunning)
            {
                Console.Write(":");
                string input = Console.ReadLine();
                if (commandIDs.ContainsKey(input))
                {
                    int cmd = -1;
                    commandIDs.TryGetValue(input.ToLower(), out cmd);

                    if (cmd == Game.CMD_HELP)
                    {
                        Console.WriteLine();
                        for (int i = 0; i <= Game.MAX_CMD; i++)
                        {
                            string cmdName = "";
                            string descript = "";
                            commands.TryGetValue(i, out cmdName);
                            cmdDescriptions.TryGetValue(i, out descript);
                            Console.WriteLine(cmdName + " - " + descript);
                        }
                        Console.WriteLine();
                        runClear = false;
                    } else if (cmd == Game.CMD_QUIT)
                    {
                        gameRunning = false;
                    }
                }

                Run();
                
                if (runClear)
                {
                    Console.Clear();
                }
                else
                {
                    runClear = true;
                }
            }
        }

        public static void Run()
        {

        }

        public static Location GetLocation(int l)
        {
            Location temp = null;
            if (rooms.ContainsKey(l))
            {
                rooms.TryGetValue(l, out temp);
            }

            return temp;
        }

        public static Character GetCharacter(int c)
        {
            Character temp = null;
            if (characters.ContainsKey(c))
            {
                characters.TryGetValue(c, out temp);
            }

            return temp;
        }

        public static Item GetItem(int i)
        {
            Item temp = null;
            if (items.ContainsKey(i))
            {
                items.TryGetValue(i, out temp);
            }

            return temp;
        }

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type the command 'help' for help with commands");
            Console.ForegroundColor = ConsoleColor.White;

            Game.Initialize();
            Game.Start();
        }
    }
}
