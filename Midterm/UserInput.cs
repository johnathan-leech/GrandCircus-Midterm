using System;
using System.Collections.Generic;

namespace Midterm
{
    class UserInput
    {
        public static void Playstate(Board game)
        {
            Tuple<int,int> inputCord;
            while(!game.WinsOrLoses())
            {
                game.DisplayBoard();
                try
                {
                    System.Console.WriteLine("(C)lick/(F)lag/(Q)mark");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F:
                            inputCord = TakeCoordinates();
                            game.IsFlagged(inputCord.Item1, inputCord.Item2, ConsoleKey.F);
                            break;
                        case ConsoleKey.C:
                            inputCord = TakeCoordinates();
                            if (!game.RevealTile(inputCord.Item1, inputCord.Item2))
                            {
                                Console.WriteLine("Cannot Click");
                            }
                            break;
                        case ConsoleKey.Q:
                            inputCord = TakeCoordinates();
                            game.IsFlagged(inputCord.Item1, inputCord.Item2, ConsoleKey.Q);
                            break;
                        default:
                            System.Console.WriteLine("Sorry I don't know that key");
                            break;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid Corn");
                }
            }
        }
       
        // needs to take user input for row, column selection
        public static Tuple<int, int> TakeCoordinates()
        {
            var indexInput = Tuple.Create(0,0);
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
                    indexInput = Tuple.Create(inputRow, inputColumn);
                    
                    i++;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                } 
            }
            return indexInput;
        }

        // need to add 'make a loop of play' in order to get continuous display and input



    }
}
