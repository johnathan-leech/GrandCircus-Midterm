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

        private void InitializeBoard()
        {
            hiddenBoard = new int[10, 10];

            displayBoard = new State[10, 10];
        }


        public void DisplayBoard()
        {
            // will use switch-case statement to display 'clicked' 'hidden' 'qmark' 'flag'
        }

        // this method would work to reveal if the tile is a flag, qmark, number, bomb
        public bool RevealTile(int row, int column)
        {
            if(displayBoard[row,column] == State.hidden)
            {
                displayBoard[row,column] = State.clicked;
                for(int i = row - 1; i <= row +1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        try
                        {
                            RevealTile(i, j);
                        }
                        catch(IndexOutOfRangeException)
                        {

                        }
                    }
                }
                return true;
            }
            return false;
        }

        private bool MakesMine() { return false; }

        public bool CompletedGame()
        {
            // will tell user if they won or lost
            return false;
        }




    }


















}
