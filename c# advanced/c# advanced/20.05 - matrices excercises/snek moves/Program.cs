using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snek_moves
{
    class Program
    {
        static string[,] mtrxstart(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = "0";
            
            return matrix;
        }
        static void printmtrx(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i, j]}");
                Console.WriteLine();
            }
        }

        static string[,] boom(string[,] matrix, int[] bomb)
        {
            int y = bomb[0];
            int x = bomb[1];
            int range = bomb[2];
            for(int i=y-range; i<=y+range&&i<matrix.GetLength(0); i++)
            {
                int expansion = i - y;
                if (expansion < 0) expansion *= -1;
                expansion = range - expansion;
                for (int j = x - expansion; j <= x + expansion&&j<matrix.GetLength(1); j++) matrix[i, j] = "1";
            }
            return matrix;
        }

        static string[,] goup(string[,] matrix)
        {
            for(int j=0; j<matrix.GetLength(1); j++)
            {
                Stack<string> up = new Stack<string>();
                for(int i=0; i<matrix.GetLength(0); i++) if (matrix[i, j] == "1") { up.Push("1"); matrix[i, j] = "0"; }
                int c = 0;
                while(up.Count!=0) { matrix[c, j] = up.Pop(); c++; }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[xy[0], xy[1]];
            matrix = mtrxstart(matrix);
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            matrix = boom(matrix, bomb);
            //printmtrx(matrix);
            //Console.WriteLine();
            matrix = goup(matrix);
            printmtrx(matrix);

            Console.ReadKey();
        }
    }
}
  