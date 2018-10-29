using System;
using System.IO;

namespace Midterm
{
    class UserInput
    {
        public static void Playstate(Board game)
        {
            
            Menu.Header();
            Tuple<int, int> inputCord;
            while (!game.WinsOrLoses())
            {
                game.DisplayBoard();
                try
                {

                    inputCord = TakeCoordinates();
                    System.Console.WriteLine("(ENTER)Click/(F)lag/(Q)mark");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F:
                            Menu.Header();
                            game.IsFlagged(inputCord.Item1, inputCord.Item2, ConsoleKey.F);
                            break;
                        case ConsoleKey.Enter:
                            
                            Menu.Header();
                            if (!game.RevealTile(inputCord.Item1, inputCord.Item2))
                            {
                                Console.WriteLine("Cannot Click");
                            }
                            break;
                        case ConsoleKey.Q:
                            
                            Menu.Header();
                            game.IsFlagged(inputCord.Item1, inputCord.Item2, ConsoleKey.Q);
                            break;
                        default:
                            Menu.Header();
                            System.Console.WriteLine("Sorry I don't know that key");
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid Corn");
                }
                Board.stopwatch.Start();
            }
            Board.counter++;
        }

        // needs to take user input for row, column selection
        public static Tuple<int, int> TakeCoordinates()
        {
            var indexInput = Tuple.Create(0, 0);
            for (int i = 0; i == 0;)
            {

                try
                {
                    Console.WriteLine();
                    Console.Write("Please enter a number for the row ");
                    Console.WriteLine();
                    int inputRow = int.Parse(Console.ReadLine());
                    Console.Write("Please enter a number for the column");
                    Console.WriteLine();
                    int inputColumn = int.Parse(Console.ReadLine());
                    indexInput = Tuple.Create(inputRow - 1, inputColumn - 1);

                    i++;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            return indexInput;

        }

        public static void RecentScores(string score)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your name to be entered on the scoreboard");
            string name = Console.ReadLine();
            //FileInfo highScore = new FileInfo(@".\HighScores.txt");
            StreamWriter scoreWriter = new StreamWriter(@".\HighScores.txt", true);
            scoreWriter.WriteLine(name + ": " + score);
            scoreWriter.Close();
        }
        public static void RecentScoreReader()
        {
            StreamReader scoreReader = new StreamReader(@".\HighScores.txt");
            for (int i = 0; i <= 10;)
            {
                string print = scoreReader.ReadLine();
                if (print == null)
                {
                    break;
                }
                Console.WriteLine(print);
            }

            scoreReader.Close();
        }
    }
}