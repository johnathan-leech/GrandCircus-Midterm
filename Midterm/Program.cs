/*
Minefield by Nicholas, Ty, Johnathan, Katie
 */
using System;
using System.Collections.Generic;
namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MINEFIELD!\n");
        }

        public static void StartMenu()
        {
            bool retry = true;
            while (retry)
            {
                Header();

                List<KeyValuePair<string, Action>> menu = new List<KeyValuePair<string, Action>>();
                menu.Add(new KeyValuePair<string, Action>("Play", () => MainMenu()));
                menu.Add(new KeyValuePair<string, Action>("Instructions", () => Instruct()));
                menu.Add(new KeyValuePair<string, Action>("Credits", () => CreditsStatic()));
                menu.Add(new KeyValuePair<string, Action>("Exit", () => Exit()));

                int menuCount = 0;
                foreach (KeyValuePair<string, Action> item in menu)
                {
                    menuCount += 1;
                    Console.WriteLine(menuCount + " - " + item.Key);
                }

                Console.Write("\nWhat would you like to do? (enter number)  ");
                int.TryParse(Console.ReadLine(), out int entry);
                bool newEntry = true;
                while (newEntry)
                {
                    if (entry > 0 && entry <= menu.Count)
                    {
                        menu[entry - 1].Value.Invoke();
                        newEntry = false;
                        retry = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, Try Again...");
                        newEntry = true;
                    }
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
                    Console.WriteLine(menuCount + " - " + item.Key);
                }

                Console.Write("\nWhat would you like to do? (enter number)  ");
                bool newEntry = true;
                while (newEntry)
                {
                    if (int.TryParse(Console.ReadLine(), out int entry) && entry > 0 && entry <= menu.Count)
                    {
                        menu[entry - 1].Value.Invoke();
                        newEntry = false;
                        retry = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        newEntry = true;
                    }
                }               
            }
        }

        public static void Instruct()
        {
            Header();
            Console.WriteLine("Instructions");///////////////////////Write Instructions
            Console.Write("\nReturn to Previous Menu?  (y/n)  ");
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
            Console.WriteLine("Credits");///////////////////////Write Credits
            Console.Write("\nReturn to Previous Menu?  (y/n)  ");
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
            Console.Write("\nGoodbye! Press ESCAPE to Exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                continue;
            }
        }

        public static void InitializeBoard(int dimension)
        {
            Header();
            Console.WriteLine($"Board dimension is {dimension}");
            Console.Write("\nReturn to Previous Menu?  (y/n)  ");
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

        public static void CustomXY()
        {
            Header();
            Console.WriteLine("user input xy & mines");
            Console.Write("\nReturn to Previous Menu?  (y/n)  ");
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
    }
}
