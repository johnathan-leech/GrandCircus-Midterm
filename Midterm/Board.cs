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
        }

        public Board(int row, int column) { }

        public Board(int row, int column, int minesPercent) { }

        private void InitializeBoard(int dimension)
        {
            hiddenBoard = new int[dimension, dimension];
            displayBoard = new State[dimension, dimension];

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
                if (hiddenBoard[row, column] == 0)
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

        private bool MakesMine(int row, int collumn)
        {
            int mine = 9;
            if (hiddenBoard[row, collumn] != mine)
            {
                hiddenBoard[row, collumn] = mine;
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = collumn - 1; j <= collumn + 1; j++)
                    {
                        if (hiddenBoard[i, j] != mine)
                        {
                            hiddenBoard[i, j] += 1;
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
