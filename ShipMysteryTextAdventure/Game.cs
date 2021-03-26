using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShipMysteryTextAdventure
{
    static class Game
    {
        //__________________
        //        IDs
        //__________________

        //Locations
        public const int LOC_PLAYERROOM = 0;
        public static Location playerroom;
        public const int NUM_LOC = 1;

        //Characters
        public const int CHAR_CAPTAIN = 0;
        public static Character captain;
        public const int NUM_CHAR = 1;

        //Items
        public const int ITEM_PLAYERPICTURE = 0;
        public static Item playerpicture;
        public const int NUM_ITEM = 1;

        //Events


        //Commands
        public const int CMD_HELP = 0;
        public const int CMD_QUIT = 1;
        public const int CMD_INSPECT = 2;
        public const int NUM_CMD = 3;
        

        public static Dictionary<string, Location> locationDict;
        public static Dictionary<string, Character> characterDict;
        public static Dictionary<string, Item> itemDict;

        public static Location[] locations;
        public static Character[] characters;
        public static Item[] items;

        public static Dictionary<int, string> commands;
        public static Dictionary<string, int> commandIDs;
        public static Dictionary<int, string> cmdDescriptions;

        public static Random rand;
        public static Player player;
        public static Location currentRoom;
        public static bool gameRunning;
        public static bool runClear; //Clear console before next run of game loop
        public static Character murderer;
        public static int daysTillRescue;

        public static void Initialize()
        {
            locationDict = new Dictionary<string, Location>();
            characterDict = new Dictionary<string, Character>();
            itemDict = new Dictionary<string, Item>();
            locations = new Location[Game.NUM_LOC];
            characters = new Character[Game.NUM_CHAR];
            items = new Item[Game.NUM_ITEM];
            commandIDs = new Dictionary<string, int>();
            commands = new Dictionary<int, string>();
            cmdDescriptions = new Dictionary<int, string>();
            player = new Player();
            rand = new Random();

            //Locations
            InitLocation(playerroom, new Location(Game.LOC_PLAYERROOM, "player room", ""));

            //Characters
            InitCharacter(captain, new Character(Game.CHAR_CAPTAIN, "captain", ""));

            //Items
            InitItem(playerpicture, new Item(Game.ITEM_PLAYERPICTURE, "picture of you", "Picture of you standing outside a hotel in Charleston, South Carolina"));
            

            //Events

            //Commands
            commandIDs.Add("help", Game.CMD_HELP);
            commands.Add(Game.CMD_HELP, "help");
            cmdDescriptions.Add(Game.CMD_HELP, "Lists all commands and descriptions");

            commandIDs.Add("quit", Game.CMD_QUIT);
            commands.Add(Game.CMD_QUIT, "quit");
            cmdDescriptions.Add(Game.CMD_QUIT, "Quits the game");

            commandIDs.Add("inspect", Game.CMD_INSPECT);
            commands.Add(Game.CMD_INSPECT, "inspect");
            cmdDescriptions.Add(Game.CMD_INSPECT, "Inspect an item (Example :inspect piano)");
        }

        public static void Start()
        {
            daysTillRescue = 5;
            RandomizeGame();
            Intro();

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

        public static void RandomizeGame()
        {
            int num = rand.Next(NUM_CHAR);
            murderer = characters[num];
            daysTillRescue += rand.Next(7);
        }

        public static void Intro()
        {
            Console.CursorVisible = false;
            Typewrite(CenterCursor("This foggy night is Thursday October 11, 1958", 10), 150);
            Typewrite(CenterCursor("Currently " + daysTillRescue + " days away from the port of Nassau, Bahamas", 11), 150);
            Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type the command 'help' for help with commands");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ProcessCommand(string input)
        {
            string arguments = "";
            if (input.Contains(' '))
            {
                arguments = input.Substring(input.IndexOf(' ') + 1);
                input = input.Substring(0, input.IndexOf(' '));
            }

            if (commandIDs.ContainsKey(input))
            {
                int cmd = -1;
                commandIDs.TryGetValue(input.ToLower(), out cmd);

                if (cmd == Game.CMD_HELP)
                {
                    Console.WriteLine();
                    for (int i = 0; i < Game.NUM_CMD; i++)
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
                else if (cmd == Game.CMD_INSPECT)
                {
                    Item i = null;
                    bool valueFound = itemDict.TryGetValue(arguments, out i);
                    if (valueFound)
                    {
                        Console.WriteLine(i.GetDescription());
                        Console.ReadLine();
                    } else
                    {
                        Console.WriteLine("That item isn't here.");
                        Delay(2000);
                    }
                    
                }
            }
        }

        public static void Update(string input)
        {
            ProcessCommand(input);
        }

        public static void Typewrite(string s, int speed)
        {
            char[] temp = s.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.Write(s.Substring(i, s.Length - i));
                    break;
                }
                Console.Write(temp[i]);
                System.Threading.Thread.Sleep(speed);
            }
        }

        public static void Delay(int millis)
        {
            System.Threading.Thread.Sleep(millis);
        }

        public static string CenterCursor(string s, int numReturns)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, numReturns);
            return s;
        }

        public static void InitLocation(Location l, Location created)
        {
            l = created;
            locations[l.GetID()] = l;
            locationDict.Add(l.GetName(), l);
        }

        public static void InitCharacter(Character c, Character created)
        {
            c = created;
            characters[c.GetID()] = c;
            characterDict.Add(c.GetName(), c);
        }

        public static void InitItem(Item i, Item created)
        {
            i = created;
            items[i.GetID()] = i;
            itemDict.Add(i.GetName(), i);
        }

        public static Location GetLocation(string s)
        {
            Location l = null;
            locationDict.TryGetValue(s, out l);
            return l;
        }

        public static Character GetCharacter(string s)
        {
            Character c = null;
            characterDict.TryGetValue(s, out c);
            return c;
        }

        public static Item GetItem(string s)
        {
            Item i = null;
            itemDict.TryGetValue(s, out i);
            return i;
        }

        public static void Main(string[] args)
        {
            Console.Title = "Ship Mystery";

            Game.Initialize();
            Game.Start();
        }
    }
}
