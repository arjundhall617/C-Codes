using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.DotNet.SudokuSolver
{
    public enum State
    {
        SUCCESS,FAILURE
    }

    class Solve
    {
        public static bool canPlace(int[,] board,int num,int curRow,int curCol)
        {
            for(int x = 0; x < board.GetLength(0); x++)
            {
                if (board[curRow, x] == num) return false;
                if (board[x, curCol] == num) return false;
            }

            int rootN = (int)Math.Sqrt((double)board.GetLength(0));
            int boxStartRow = curRow - curRow % rootN;
            int boxStartCol = curCol - curCol % rootN;
            for (int r = boxStartRow; r < boxStartRow + rootN; ++r)
            {
                for (int c = boxStartCol; c < boxStartCol + rootN; ++c)
                {
                    if (board[r, c] == num) return false;
                }
            }
            return true;
        }
        public static State SolveSudoku(int[,] board,int curRow,int curCol)
        {
            if (curRow == board.GetLength(0))
                return State.SUCCESS;
            if(curCol==board.GetLength(1))
            {
                State statusFromNextRow = SolveSudoku(board, curRow + 1, 0);
                return statusFromNextRow;
            }
            if(board[curRow,curCol]!=0)
            {
                State statusFromNextCell = SolveSudoku(board, curRow, curCol + 1);
                return statusFromNextCell;
            }

            for(int num = 1; num <= board.GetLength(0); num++)
            {
                bool check = canPlace(board, num, curRow, curCol);
                if (check == true)
                {
                    board[curRow, curCol] = num;
                    State statusOfRemBoard = SolveSudoku(board, curRow, curCol + 1);
                    if (statusOfRemBoard == State.SUCCESS)
                    {
                        
                        return State.SUCCESS;
                    }
                    else
                        board[curRow, curCol] = 0;
                }
               
            }
            return State.FAILURE;
        }
        public static void main()
        {
            Console.WriteLine("Enter the size of the matrix");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] board = new int[n, n];
            Program.InputMatrix(board);
            State status = SolveSudoku(board, 0, 0);
            if (status == State.SUCCESS)
                Program.OutputMatrix(board);
            else
                Console.WriteLine("The Sudoku cannot be solved");
        }
    }
}
