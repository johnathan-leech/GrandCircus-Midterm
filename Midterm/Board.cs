using System;

namespace Midterm
{
    public enum State { hidden, flag, qmark, clicked }

    class Board
    {

        private int rows;
        private int columns;
        private double minesPercent;
        private int[,] hiddenBoard;
        private State[,] displayBoard;


        //private int rows;
        //public int Rows
        //{
        //    get
        //    {
        //        return rows;
        //    }
        //    set
        //    {
        //        rows = value;
        //    }
        //}

        //private int columns;
        //public int Columns
        //{
        //    get
        //    {
        //        return columns;
        //    }
        //    set
        //    {
        //        columns = value;
        //    }
        //}

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

        private void InitializeBoard(int dimension)
        {
            hiddenBoard = new int[dimension, dimension];
            displayBoard = new State[dimension, dimension];

        }
        private void InitializeBoard()
        {
            hiddenBoard = new int[rows, columns];
            displayBoard = new State[rows, columns];
            for(int i =0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    hiddenBoard[i, j] = 0;
                    displayBoard[i, j] = State.hidden;
                }
            }
        }


        public void DisplayBoard()
        {
            char displayChar = ' ';
            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    switch(displayBoard[i,j])
                    {
                        case State.clicked:
                            displayChar = (char)(hiddenBoard[i, j] + '0');
                            if (displayChar == 9)
                                displayChar = '\u0042'; //'*'
                            if (displayChar == 0)
                                displayChar = ' ';
                            break;
                        case State.flag:
                            displayChar = '\u0213'; //''
                            break;
                        case State.hidden:
                            displayChar = '\u0254'; //''
                            break;
                        case State.qmark:
                            displayChar = '?';
                            break;
                    }
                    Console.Write(displayChar);
                }
                Console.WriteLine();
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
                else if(hiddenBoard[row,column] == 9)
                {
                    
                }
                return true;
            }
            return false;
        }
        private void MakeAllMines()
        {
            Random r = new Random();
            // trys to create a mine and adds one to i each time a mine is made.
            for (int i = 0; i < rows * columns * minesPercent; i += MakesMine(r.Next() % rows, r.Next() % columns) ? 1 : 0) ;
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

            public bool CompletedGame()
        {
            bool isMine = true;
            if (isMine == true)
            {
                Console.WriteLine("BOOOOOOOOM!");
                Console.WriteLine("Oh no, you hit a bomb!");
                return true;
            }
            return false;
        }




    }


















}
