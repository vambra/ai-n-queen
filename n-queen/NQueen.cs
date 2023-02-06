using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_queen
{
    class NQueen
    {
        private int n = 4;
        private List<int[,,]> allConfigurations;
        
        public int[,,] solve(int n)
        {
            this.n = n;
            allConfigurations = new List<int[,,]>();
            int[,,] board = new int[this.n, this.n, 2];
            board[0, 0, 1] = 0;

            Console.WriteLine("Starting board");
            printBoard(board);

            // if unsolvable for n queens
            if (solveRow(board, 0) == false)
                board = getClosestSolution();

            Console.WriteLine("Solution");
            printBoard(board);
            return board;
        }

        private bool solveRow(int[,,] board, int row)
        {
            if (row >= n)
                return true;

            for (int i = 0; i < n; i++)
            {
                if (canPlace(board, row, i))
                {
                    board[row, i, 0] = 1;
                    board[0, 0, 1]++;
                    Console.WriteLine("Step " + (row + 1));
                    printBoard(board);

                    // check rest of rows
                    if (solveRow(board, row + 1) == true)
                        return true;

                    // if the placement is unsolvable

                    // add copy to configuration list
                    allConfigurations.Add((int[,,])board.Clone());

                    // backtrack board
                    board[row, i, 0] = 0;
                    board[0, 0, 1]--;
                }
            }
            // if row is unsolvable
            return false;
        }

        private bool canPlace(int[,,] board, int row, int col)
        {
            // check row
            for (int i = 0; i < row; i++)
                if (board[i, col, 0] == 1)
                    return false;

            // check column
            for (int i = 0; i < col; i++)
                if (board[row, i, 0] == 1)
                    return false;

            // check \ upwards
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j, 0] == 1)
                    return false;

            // check / upwards
            for (int i = row, j = col; j< n && i >= 0; i--, j++)
                if (board[i, j, 0] == 1)
                    return false;

            return true;
        }

        private int[,,] getClosestSolution()
        {
            int maxQueens = 0;
            int[,,] maxBoard = null;
            foreach (int[,,] board in allConfigurations)
            {
                if (board[0, 0, 1] > maxQueens)
                {
                    maxQueens = board[0, 0, 1];
                    maxBoard = board;
                }
            }
            return maxBoard;
        }

        private void printBoard(int[,,] board)
        {
            Console.WriteLine(boardString(board));
        }

        public string boardString(int[,,] board)
        {
            string str = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    str += board[i, j, 0] + " ";
                str += "\n";
            }
            return str;
        }
    }
}
