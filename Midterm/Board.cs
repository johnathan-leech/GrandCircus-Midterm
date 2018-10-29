using System;
using System.Diagnostics;

namespace Midterm
{
    public enum State { hidden, flag, qmark, clicked }

    class Board
    {
        public bool isMine;
        private int rows;
        private int columns;
        private int numMines;
        private double minesPercent;
        private int[,] hiddenBoard;
        private State[,] displayBoard;
        public static int counter = 0;
        public static Stopwatch stopwatch = new Stopwatch();

        public Board()
        {
            rows = 10;
            columns = 10;
            minesPercent = .15;
            InitializeBoard();
        }

        public Board(int row, int column)
        {
            rows = row;
            columns = column;
            minesPercent = .15;
            InitializeBoard();
        }

        public Board(int row, int column, double minesPercent)
        {
            rows = row;
            columns = column;
            this.minesPercent = minesPercent;
            InitializeBoard();
        }

        //sending dimensions from UserInput class
        //////////////////////////////////sending dimensions from Menu class
        public static void BoardDimensions(int xy)
        {
            int row = xy;
            int column = xy;
            double minesPercent = .15;
            Board gameBoard = new Board(row, column, minesPercent);

            Console.Clear();
            UserInput.Playstate(gameBoard);
        }

        public static void BoardDimensions(int x, int y, int mines)
        {
            int row = x;
            int column = y;
            int minesTotal = mines;
            double minesPercent = mines / 100.0;
            Board gameBoard = new Board(row, column, minesPercent);
            Console.Clear();
            UserInput.Playstate(gameBoard);
        }

        private void InitializeBoard()
        {
            hiddenBoard = new int[rows, columns];
            displayBoard = new State[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    hiddenBoard[i, j] = 0;
                    displayBoard[i, j] = State.hidden;
                }
            }
            MakeAllMines();
            stopwatch.Start();
        }

        public void DisplayBoard()
        {
            int yAxisCounter = 0;
            int xAxisCounter = 0;
            char displayChar = ' ';

            Console.Write("    ");

            for (; yAxisCounter < columns; yAxisCounter++)
            {
                Console.Write("{0, -3}", yAxisCounter + 1);
            }
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0, -4}", xAxisCounter + 1);
                for (int j = 0; j < columns; j++)
                {
                    //yAxisCounter++;
                    switch (displayBoard[i, j])
                    {
                        case State.clicked:
                            displayChar = (char)(hiddenBoard[i, j] + '0');
                            setColor(hiddenBoard[i,j]);
                            if (displayChar == '9')
                            {
                                displayChar = '\u0042'; //'*'
                            }
                            if (displayChar == '0')
                            {
                                displayChar = '-';
                            }
                            break;
                        case State.flag:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            displayChar = 'F'; //''
                            break;
                        case State.hidden:
                            //Console.ForegroundColor = ConsoleColor.Cyan;
                            displayChar = '#'; //''
                            break;
                        case State.qmark:
                            displayChar = '?';
                            break;
                    }
                    Console.Write(displayChar + "  ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                xAxisCounter++;
                Console.WriteLine();
            }
        }
        public void setColor(int colorCode)
        {
            switch (colorCode)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
            }
        }

        // this method would work to reveal if the tile is a flag, qmark, number, bomb
        public bool RevealTile(int row, int column)
        {
            if (displayBoard[row, column] == State.hidden)
            {
                displayBoard[row, column] = State.clicked;
                if (hiddenBoard[row, column] == 0) // If there are no mines next to this one, reveal all the tiles next to it. 
                {
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                        {
                            try
                            {
                                RevealTile(i, j);
                            }
                            catch (IndexOutOfRangeException)
                            {

                            }
                        }
                    }
                }
                else if (hiddenBoard[row, column] == 9)
                {
                    isMine = true;
                }
                return true;
            }
            return false;
        }

        private void MakeAllMines()
        {
            Random r = new Random();
            // trys to create a mine and adds one to i each time a mine is made.
            int i;
            for (i = 0; i < rows * columns * minesPercent; i += MakesMine(r.Next() % rows, r.Next() % columns) ? 1 : 0) ;
            numMines = i;
        }

        public bool MakesMine(int row, int column)
        {
            int mine = 9;
            if (hiddenBoard[row, column] != mine)
            {
                hiddenBoard[row, column] = mine;

                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        try
                        {
                            if (hiddenBoard[i, j] != mine)
                            {
                                hiddenBoard[i, j] += 1;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                return true;
            }
            return false;
        }

        public bool WinsOrLoses()
        {
            if (isMine == true)
            {
                Console.WriteLine("BOOOOOOOOM!");
                Console.WriteLine("Oh no, you hit a bomb!");
                DisplayHiddenBoard();  // <-- display hidden board
                Console.ReadLine();

                return true;
            }

            // number of clicked tiles should be equal to all tiles - mines.
            int numberClicked = 0;
            foreach (State tile in displayBoard)
            {
                if (tile == State.clicked)
                {
                    numberClicked++;
                }
            }

            if (displayBoard.Length - (numMines) == numberClicked)
            {
                DisplayHiddenBoard();  // <-- display hidden board
                
                UserInput.RecentScores(stopwatch.ToString());
                UserInput.RecentScoreReader();

                Console.ReadLine();

                return true;
            }
            return false;
        }

        public void IsFlagged(int row, int column, ConsoleKey inputKey)
        {
            if (displayBoard[row, column] == State.clicked)
            {
                Console.WriteLine("This space is already clicked!");
            }
            else if (inputKey == ConsoleKey.F)
            {
                if (displayBoard[row, column] == State.flag)
                {
                    displayBoard[row, column] = State.hidden;
                }
                else
                {
                    displayBoard[row, column] = State.flag;
                }
            }
            else if (inputKey == ConsoleKey.Q)
            {
                if (displayBoard[row, column] == State.qmark)
                {
                    displayBoard[row, column] = State.hidden;
                }
                else
                {
                    displayBoard[row, column] = State.qmark;
                }
            }
        }

        public void DisplayHiddenBoard()
        {
            char temp = ' ';
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (hiddenBoard[i, j])
                    {
                        case 0:
                            temp = '-';
                            break;
                        case 9:
                            temp = '*';
                            break;
                        default:
                            temp = (char)('0' + hiddenBoard[i, j]);
                            break;
                    }

                    Console.Write(temp + " ");
                }
                Console.WriteLine();
            }
        }


    }
}
