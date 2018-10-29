using System;
using System.IO;
using System.Collections.Generic;


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
            //Board.counter++;
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

        public static void RecentScores(string score, string mode)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your name to be entered on the scoreboard");
            string name = Console.ReadLine();
            StreamWriter scoreWriter = new StreamWriter(@".\HighScores.txt", true);
            scoreWriter.WriteLine(score+ " "+name+" "+mode);
            scoreWriter.Close();
        }
        public static void RecentScoreReader()
        {
            
            Menu.Header();
            List<string> scoreList = new List<string>();
            StreamReader scoreReader = new StreamReader(@".\HighScores.txt");
            
            for (int i = 0; i < 10; i++)
            {
                string print = scoreReader.ReadLine();
                if (print == null)
                {
                    break;
                }
                
                scoreList.Add(print);

                
                
            }
            scoreList.Sort();
            for(int i = 0; i < scoreList.Count; i++)
            {
                    string[] sortedScoreList = scoreList[i].Split(' ');
                    Console.WriteLine("{0}'s Score: {1} Board Size {2}", sortedScoreList[1], sortedScoreList[0], sortedScoreList[2]);
            }

            scoreReader.Close();
            Console.ReadLine();
        }
    }
}