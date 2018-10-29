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
                    inputCord = TakeCoordinates(game.Rows, game.Columns);
                    System.Console.WriteLine("(C)lick - (F)lag - (Q)mark");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F:
                            Menu.Header();
                            game.IsFlagged(inputCord.Item1, inputCord.Item2, ConsoleKey.F);
                            break;
                        case ConsoleKey.C:

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
            //Board.counter++;
        }

        // needs to take user input for row, column selection
        public static Tuple<int, int> TakeCoordinates(int maxRow, int maxCol)
        {
            var indexInput = Tuple.Create(0, 0);

            Console.WriteLine();
            Console.Write("Please enter a number for the row({0}-{1})", 1, maxRow);
            Console.WriteLine();

            int inputRow;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out inputRow))
                {
                    if (inputRow > 0 && inputRow <= maxRow)
                        break;
                    Console.WriteLine("That is not within the range");
                }
                else
                {
                    Console.WriteLine("That is not a number");
                }
            }
            Console.Write("Please enter a number for the column({0}-{1})", 1, maxCol);
            Console.WriteLine();
            int inputColumn;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out inputColumn))
                {
                    if (inputRow > 0 && inputRow <= maxCol)
                        break;
                    Console.WriteLine("That is not within the range");
                }
                Console.WriteLine("That is not a number");
            }
            indexInput = Tuple.Create(inputRow - 1, inputColumn - 1);

            return indexInput;
        }

        public static void RecentScores(string score, string mode)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your name to be entered on the scoreboard");
            string name = Console.ReadLine();
            StreamWriter scoreWriter = new StreamWriter(@".\HighScores.txt", true);
            scoreWriter.WriteLine(name + " Time: " + score + " Board Size: " + mode);
            scoreWriter.Close();
            Board.stopwatch.Reset();
        }

        public static void RecentScoreReader()
        {
            Menu.Header();
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
            Console.ReadLine();
        }
    }
}