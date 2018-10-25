using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Welcome to MINEFIELD!");
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
                bool newEntry = true;
                while (newEntry)
                {
                    if (int.TryParse(Console.ReadLine(), out int entry) && entry > 0 && entry <= menu.Count)
                    {
                        menu[entry - 1].Value.Invoke();
                        newEntry = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
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
            bool retry = true;
            while (retry)
            {
                Console.WriteLine("Instructions");///////////////////////Write Instructions
                retry = Retry();
            }
        }

        public static void CreditsStatic()
        {
            bool retry = true;
            while (retry)
            {
                Console.WriteLine("Credits");///////////////////////Write Credits
                retry = Retry();
            }
        }

        public static bool Retry()
        {
            bool valid = false;
            bool retry = true;

            while (!valid)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    valid = true;
                    retry = true;
                }
                else if (key == ConsoleKey.N)
                {
                    valid = true;
                    retry = false;
                }
                else
                {
                    Console.Write("\nReturn to Previous Menu?  (y/n)  ");
                    valid = false;
                    retry = true;
                }
            }
            return retry;
        }

        public static void Exit()
        {
            ConsoleKey key = Console.ReadKey().Key;

            Console.Write("\nGoodbye! Press ESCAPE to Exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey().Key;
            }
        }

        public static void InitializeBoard(int dimension)
        {
            Console.WriteLine($"Board dimension is {dimension}");
            Console.ReadLine();
        }

        public static void CustomXY()
        {
            Console.WriteLine("user input xy & mines");
            Console.ReadLine();
        }
    }
}
