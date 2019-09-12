using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrices_n_shit
{
    class Program
    {
        class Area
        {
            public int squares;
            public int Istart;
            public int Jstart;

            public Area (int sq, int i, int j)
            {
                squares = sq;
                Istart = i;
                Jstart = j;
            }
        }
        static void PrintMtrx(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j]);
                Console.WriteLine();
                    }
        }
        static bool OutOfBounds(int i, int j, char[,] matrix)
        {
            bool oob = false;
            if (i < 0) oob = true;
            if (i >= matrix.GetLength(0)) oob = true;
            if (j < 0) oob = true;
            if (j >= matrix.GetLength(1)) oob = true;
            return oob;
        }
        static int Spotcheck(int i, int j, char[,] matrix)
        {
            int squares = 0;
            if(!OutOfBounds(i,j,matrix))
            if (matrix[i, j] != '*')
            {
                squares++;
                matrix[i, j] = '*';
                squares += Spotcheck(i + 1, j, matrix);
                squares += Spotcheck(i, j + 1, matrix);
                squares += Spotcheck(i - 1, j, matrix);
                squares += Spotcheck(i, j - 1, matrix);

            }
            return squares;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, m];
            for(int i=0; i<n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < m; j++) matrix[i, j] = row[j];
            }

            List<Area> spots = new List<Area>();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) if (matrix[i, j] != '*') spots.Add(new Area(Spotcheck(i, j, matrix), i, j));
            spots = spots.OrderByDescending(x => x.squares).ToList();
            Console.WriteLine("Total areas found: " + spots.Count);
            for(int i=0; i<spots.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({spots[i].Istart}, {spots[i].Jstart}), size: {spots[i].squares}");
            }
        }
    }
}
