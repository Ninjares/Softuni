using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace le_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrix = { 2, 2 };
                //Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] helloNeo = new int[matrix[0], matrix[1]];
            int[,] yeet =
            {
                {10,20,30,40 },
                {11,12,13,14 },
            };

            for(int i=0; i<yeet.GetLength(0); i++)
            {
                for (int j = 0; j < yeet.GetLength(1); j++) Console.Write($"{yeet[i, j]} ");
                Console.WriteLine();
            }

            foreach(var el in yeet)
            {
                Console.WriteLine(string.Join(" ", el));
            }
            Console.WriteLine(helloNeo.Rank);

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[2];

            int[][] jaggedinput = new int[5][];
            for(int row=0; row<jaggedinput.Length; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedinput[row] = new int[numbers.Length];
                Array.Copy(numbers, jaggedinput[row], numbers.Length);  //copies the array rather than just setting the memory address of the array being "copied"
                numbers[0] = -1;

            }

            foreach(int[] arr in jaggedinput)
            {
                Console.WriteLine(string.Join(", ", arr));
            }

            Console.ReadKey();
        }
    }
}
