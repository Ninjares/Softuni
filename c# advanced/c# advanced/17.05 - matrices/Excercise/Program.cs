using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program
    {
        static void print2Dmtrx(int[,] matrix)
        {
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i, j]} ");
                Console.WriteLine(string.Join(", ", matrix.));
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[,] matrix = 
            {
                {7, 1, 3, 3, 2, 1},
                {1, 3, 9, 8, 5, 6},
                {4, 6, 7, 9, 1, 0}
            };
            print2Dmtrx(matrix);


            int maxsum=int.MinValue;
            int[] maxsumloc = new int[2];
            for(int i=0; i<matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (sum > maxsum)
                    {
                        maxsum = sum;
                        maxsumloc[0] = i;
                        maxsumloc[1] = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxsumloc[0], maxsumloc[1]]} {matrix[maxsumloc[0], maxsumloc[1] + 1]}\n" +
                $"{matrix[maxsumloc[0] + 1, maxsumloc[1]]} {matrix[maxsumloc[0]+1, maxsumloc[1] + 1]}\n" +
                $"{maxsum}");
            Console.ReadKey();
        }
    }
}
