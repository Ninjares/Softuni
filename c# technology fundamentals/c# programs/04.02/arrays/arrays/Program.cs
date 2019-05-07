using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //<type>[] <name> = new <type><ammount>; [] says "this is going to be an array"
            int[] array = new int[5];
            var arr2 = new int[5];
            // int* point = &array[1]; Pointers work in unsafe mode?
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            double avg = (double)sum / array.Length;
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine("\nsum: {0} avg: {1}", sum, avg);

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Console.WriteLine(daysOfWeek[int.Parse(Console.ReadLine()) - 1]); //check out the invert if fuction with a screwdriver icon


            string values = Console.ReadLine();
            string[] valuesAsStrings = values.Split();
            int[] numbers = new int[valuesAsStrings.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(valuesAsStrings[i]);
                Console.Write(numbers[i] + " ");
            }//or "int[] valueAsStrings = values.Split().Select(int.Parse).ToArray();"
            Console.WriteLine();
            /* unsafe
            {
                int* p = new int[5];
                p[0] = 1;
                p[1] = 2;
            } */

            string[] arr =
            {
                "Sofia", "Plovdiv", "Varna", "Burgas"
            };
            Array.Sort(arr);
            Array.BinarySearch(arr, "Plovdiv");
            string allCities = string.Join(", ", arr);
            Console.WriteLine(allCities);


            //foreach only 
            foreach (string city in arr)
            {
                Console.Write(city + "; ");
            }

            int[,] mul_X2 = new int[3, 4]; //   [ <0>, <1>, <2>, .... ]
            int[,,] mul_X3 = new int[5, 5, 5];
            for (int row = 0; row < mul_X2.GetLength(0); row++)
                for (int col = 0; col < mul_X2.GetLength(1); col++) ;
           Console.ReadKey();
        }
    }
}
