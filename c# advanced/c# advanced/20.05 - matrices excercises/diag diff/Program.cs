using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diag_diff
{
    class Program
    {
        static string[,] mtrxinput(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = line[j]; 
            }
            return matrix;
        }
        static void printmtrx(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i,j]} ");
                Console.WriteLine();
                    }
        }
        static void Main(string[] args)
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[xy[0],xy[1]];
            matrix = mtrxinput(matrix);
            Console.ReadKey();
        }
    }
}
