using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.DotNet.SudokuSolver
{
    class Program
    {
        public static void InputMatrix(int[,] mat)
        {
            string[] inputStr = System.IO.File.ReadAllLines(@"C:\Users\arjundhall\source\repos\in.txt");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                string[] lines = inputStr[i].Split(' ');
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = int.Parse(lines[j]);
                }
            }

        }

        public static void OutputMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
        }



        static void Main(string[] args)
        {
            Solve.main();
            
            Console.ReadKey();
        }
    }
}
