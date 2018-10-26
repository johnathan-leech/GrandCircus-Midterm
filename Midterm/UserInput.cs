using System;
using System.Collections.Generic;

namespace Midterm
{
    class UserInput
    {
        public static void Header()//Header clears each page and displays title
        {
            Console.Clear();
            Console.WriteLine($"\n{new string(' ', 30)}Welcome to MINEFIELD!\n");
        }

        public static void StartMenu()
        {
            bool retry = true;//bool to loop entire method when entry is invalid
            while (retry)
            {
                Header();

                List<KeyValuePair<string, Action>> menu = new List<KeyValuePair<string, Action>>();//List with KeyValuePairs for menu: string = display; Action = method call; to add: just menu.Add with no additional code changes
                menu.Add(new KeyValuePair<string, Action>("Play", () => MainMenu()));
                menu.Add(new KeyValuePair<string, Action>("Instructions", () => Instruct()));
                menu.Add(new KeyValuePair<string, Action>("Credits", () => CreditsStatic()));
                menu.Add(new KeyValuePair<string, Action>("Exit", () => Exit()));

                int menuCount = 0;//globally declared to use in multiple nests, changes dynamically based on menu items
                foreach (KeyValuePair<string, Action> item in menu)
                {
                    menuCount += 1;//counter to display selection options
                    Console.WriteLine(new string(' ', 33) + menuCount + " - " + item.Key);
                }

                Console.Write($"\n{new string(' ', 22)}What would you like to do? (enter number)  ");
                int entry = 0;
                if (menuCount < 10)//set condition to equal 1 key press
                {
                    ConsoleKey key = Console.ReadKey().Key;//reads the key
                    entry = KeyToNum(key);//sends key to method that converts to int
                }
                else
                {
                    int.TryParse(Console.ReadLine(), out entry);//reads the line (user must press enter)
                }

                if (entry > 0 && entry <= menu.Count)//checks for valid entry
                {
                    menu[entry - 1].Value.Invoke();//invokes method
                    retry = false;
                }
            }
        }

        public static void MainMenu()
        {
            bool retry = true;
            while (retry)
            {
                Header();
                List<KeyValuePair<string, Action>> menu = new List<KeyValuePair<string, Action>>();
                menu.Add(new KeyValuePair<string, Action>("Beginner", () => InitializeBoard(10)));
                menu.Add(new KeyValuePair<string, Action>("Easy", () => InitializeBoard(15)));
                menu.Add(new KeyValuePair<string, Action>("Intermediate", () => InitializeBoard(20)));
                menu.Add(new KeyValuePair<string, Action>("Hard", () => InitializeBoard(30)));
                menu.Add(new KeyValuePair<string, Action>("Expert", () => InitializeBoard(40)));
                menu.Add(new KeyValuePair<string, Action>("Custom", () => CustomXY()));
                menu.Add(new KeyValuePair<string, Action>("Return to Start Menu", () => StartMenu()));
                menu.Add(new KeyValuePair<string, Action>("Exit", () => Exit()));

                int menuCount = 0;
                foreach (KeyValuePair<string, Action> item in menu)
                {
                    menuCount += 1;
                    Console.WriteLine(new string(' ', 33) + menuCount + " - " + item.Key);
                }

                Console.Write($"\n{new string(' ', 22)}What would you like to do? (enter number)  ");
                int entry = 0;
                if (menuCount < 10)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    entry = KeyToNum(key);
                }
                else
                {
                    int.TryParse(Console.ReadLine(), out entry);
                }

                if (entry > 0 && entry <= menu.Count)
                {
                    Board b = menu[entry - 1].Value.Invoke();
                    retry = false;
                }
            }
        }

        public static void Instruct()
        {
            Header();
            Console.WriteLine($"\n{new string(' ', 36)}TO PLAY:\n\n{new string(' ', 26)}1. Select difficulty level.\n{new string(' ', 31)}*FOR CUSTOM BOARD*\n{new string(' ', 20)}Enter board dimension(s) & total mines,\n{new string(' ', 31)}or select default.\n\n{new string(' ', 22)}2. Select whether you would like to:\n{new string(' ', 32)}Step on square - \n{new string(' ', 20)}This could result in detonating a mine!\n{new string(' ', 30)}Flag a square (f) - \n{new string(' ', 18)}Mark squares you're certain contain a mine.\n{new string(' ', 28)}Question a square (?) - \n{new string(' ', 19)}If you're not 100% certain there is a mine.\n\n{new string(' ', 12)}3. Enter coordinates of the square you'd like to select.\n\n{new string(' ', 8)}4. Continue until all squares are either stepped on or flagged.");///////////////////////Write Instructions//note we need to set available flags to # of mines and display how many are unused.//possibly ask if square or rectangular board, then dimension input would equal x&y or x(or)y
            Console.Write($"\n{new string(' ', 25)}Return to Previous Menu?  (y/n)  ");
            bool yes = YesNo();
            if (yes)
            {
                MainMenu();
            }
            else
            {
                Exit();
            }
        }

        public static void CreditsStatic()
        {
            Header();
            //string padding = new string(' ', 40);//padding set to default console width divided by 2, to use: subtract 1/2 the line length
            Console.WriteLine($"\n{new string(' ', 36)}CREDITS\n\n{new string(' ', 31)}DEVELOPMENT TEAM: \n\n{new string(' ', 28)}LEADER: NICHOLAS LANDAU\n{new string(' ', 32)}JONATHAN  LEECH\n{new string(' ', 33)}KATIE HARRELL\n{new string(' ', 35)}TY CARRON\n\n");///////////////////////Write Credits///////NEED TEAM NAME!
            Console.Write($"\n{new string(' ', 25)}Return to Previous Menu?  (y/n)  ");
            bool yes = YesNo();
            if (yes)
            {
                MainMenu();
            }
            else
            {
                Exit();
            }
        }

        public static bool YesNo()
        {
            bool valid = false;
            bool yes = true;

            while (!valid)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    valid = true;
                    yes = true;
                }
                else if (key == ConsoleKey.N)
                {
                    valid = true;
                    yes = false;
                }
                else
                {
                    valid = false;
                    yes = true;
                }
            }
            return yes;
        }

        public static void Exit()
        {
            Console.Write($"\n{new string(' ', 24)}Goodbye! Press ESCAPE to Exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                continue;
            }
        }

        public static Board InitializeBoard(int dimension)///////////////////////////////////temp method to test menus
        {
            Header();
            Console.WriteLine($"\n{new string(' ', 30)}Board dimension is {dimension}");
            Board newgame = new Board(dimension, dimension);
            return newgame;
            Console.Write($"\n{new string(' ', 25)}Return to Previous Menu?  (y/n)  ");
            bool yes = YesNo();
            if (yes)
            {
                MainMenu();
            }
            else
            {
                Exit();
            }
        }

        public static void CustomXY()///////////////////////////////////////////////////temp method to test menus
        {
            Header();
            Console.WriteLine($"{new string(' ', 30)}user input xy & mines");
            Console.Write($"\n{new string(' ', 25)}Return to Previous Menu?  (y/n)  ");
            bool yes = YesNo();
            if (yes)
            {
                MainMenu();
            }
            else
            {
                Exit();
            }
        }

        public static int KeyToNum(ConsoleKey key)
        {
            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { return 1; }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { return 2; }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) { return 3; }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4) { return 4; }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5) { return 5; }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6) { return 6; }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7) { return 7; }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8) { return 8; }
            else if (key == ConsoleKey.D9 || key == ConsoleKey.NumPad9) { return 9; }
            else { return 0; }
        }
    }
}
