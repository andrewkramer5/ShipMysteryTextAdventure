using System;
using System.Collections.Generic;
using System.Windows.Input;
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
        public static Location navigation;

        //Characters
        public static Character captain;

        //Items
        public static Item shipWheel;

        //Events


        //Commands
        public const int CMD_HELP = 0;
        public const int CMD_QUIT = 1;
        public const int MAX_CMD = 1;
        

        public static Dictionary<string, Location> locations;
        public static Dictionary<string, Character> characters;
        public static Dictionary<string, Item> items;

        public static Dictionary<int, string> commands;
        public static Dictionary<string, int> commandIDs;
        public static Dictionary<int, string> cmdDescriptions;

        public static Player player;
        public static Location currentRoom;
        public static bool gameRunning;
        public static bool runClear; //Clear console before next run of game loop

        public static void Initialize()
        {
            locations = new Dictionary<string, Location>();
            characters = new Dictionary<string, Character>();
            items = new Dictionary<string, Item>();
            commandIDs = new Dictionary<string, int>();
            commands = new Dictionary<int, string>();
            cmdDescriptions = new Dictionary<int, string>();
            player = new Player();

            //Locations
            InitLocation(navigation, new Location("navigation"));

            //Characters

            //Items

            //Events

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
            runClear = true;

            while (gameRunning)
            {
                Console.Write(":");
                string input = Console.ReadLine();

                Update(input);
                
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

        public static void ProcessCommand(string input)
        {
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
                }
                else if (cmd == Game.CMD_QUIT)
                {
                    gameRunning = false;
                }
            }
        }

        public static void Update(string input)
        {
            ProcessCommand(input);
        }

        public static void Typewrite(string s)
        {
            char[] temp = s.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i]);
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void Delay(int millis)
        {
            System.Threading.Thread.Sleep(millis);
        }

        public static void InitLocation(Location l, Location created)
        {
            l = created;
            locations.Add(l.GetName(), l);
        }

        public static void InitCharacter(Character c, Character created)
        {
            c = created;
            characters.Add(c.GetName(), c);
        }

        public static void InitItem(Item i, Item created)
        {
            i = created;
            items.Add(i.GetName(), i);
        }

        public static Location GetLocation(string s)
        {
            Location l = null;
            locations.TryGetValue(s, out l);
            return l;
        }

        public static Character GetCharacter(string s)
        {
            Character c = null;
            characters.TryGetValue(s, out c);
            return c;
        }

        public static Item GetItem(string s)
        {
            Item i = null;
            items.TryGetValue(s, out i);
            return i;
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
