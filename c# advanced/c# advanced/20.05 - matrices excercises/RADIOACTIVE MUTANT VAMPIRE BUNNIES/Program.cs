using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADIOACTIVE_MUTANT_VAMPIRE_BUNNIES
{
    class Program
    {
        static char[,] mtrxinput(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = line[j];
            }
            return matrix;
        }

        static void printmatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i, j]}");
                Console.WriteLine();
            }
        }

        static int[] playerloc(char[,] matrix)
        {
            int[] xy = new int[2];
            int pr = -1; //playerrow
            int pc = -1; //playercolumn
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] == 'P') { pr = i; pc = j; break; }
            xy[0] = pr;
            xy[1] = pc;
            return xy;
        }
        static char[,] move (char[,] matrix, char move, int[] pp)
        {
            int pr = pp[0];
            int pc = pp[1];
            switch (move)
            {
                case 'U':
                    {
                        if (pr - 1 < 0) matrix[pr, pc] = '.';
                        else
                        {
                            matrix[pr - 1, pc] = 'P';
                            matrix[pr, pc] = '.';
                        }
                        break;
                    }
                case 'D':
                    {
                        if (pr + 1 >= matrix.GetLength(0)) matrix[pr, pc] = '.';
                        else
                        {
                            matrix[pr+1, pc] = 'P';
                            matrix[pr, pc] = '.';
                        }
                        break;
                    }
                case 'L':
                    {
                        if (pc - 1 < 0) matrix[pr, pc] = '.';
                        else
                        {
                            matrix[pr, pc-1] = 'P';
                            matrix[pr, pc] = '.';
                        }
                        break;
                    }
                case 'R':
                    {
                        if (pc + 1 >= matrix.GetLength(1)) matrix[pr, pc] = '.';
                        else
                        {
                            matrix[pr, pc+1] = 'P';
                            matrix[pr, pc] = '.';
                        }
                        break;
                    }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        if (i - 1 >= 0)                  matrix[i - 1, j] = 'b';
                        if (i + 1 < matrix.GetLength(0)) matrix[i + 1, j] = 'b';
                        if (j - 1 >= 0)                  matrix[i, j - 1] = 'b';
                        if (j + 1 < matrix.GetLength(1)) matrix[i, j + 1] = 'b';
                    }
                }
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] == 'b') matrix[i, j] = 'B';
                    return matrix;
        }
        static void Main(string[] args)
        {
            
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[xy[0], xy[1]];
            matrix = mtrxinput(matrix);
            string moves = Console.ReadLine();

            bool playeralive = true;
            int[] playerlocation = playerloc(matrix);
            int[] lastlocation = playerloc(matrix);
            for (int i=0; i<moves.Length; i++)
            {
                if (playerlocation[0] != -1 && playerlocation[0] != -1)
                {
                    matrix = move(matrix, moves[i], playerlocation);
                    playerlocation = playerloc(matrix);
                    printmatrix(matrix);
                }
                Console.WriteLine();
            }

            //printmatrix(matrix);
            Console.ReadKey();
        }
    }
}
