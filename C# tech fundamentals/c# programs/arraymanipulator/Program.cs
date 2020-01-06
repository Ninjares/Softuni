using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_manipulator
{
    class Program
    {
        static void printarray(int[] array)
        {
            foreach (int num in array) Console.Write(num + " ");
            Console.WriteLine();
        }

        static int[] exchange(int[] array, int indx)
        {
            int index = array.Length - indx;
            int[] firsthalf = new int[index];
            for (int i = 0; i < index; i++) firsthalf[i] = array[i];
            int[] secondhalf = new int[array.Length - index];
            for (int i = 0; i < array.Length - index; i++) secondhalf[i] = array[i + index];

            int[] join = new int[array.Length];
            for (int i = 0; i < secondhalf.Length; i++) join[i] = secondhalf[i];
            for (int i = 0; i < firsthalf.Length; i++) join[i + secondhalf.Length] = firsthalf[i];
            //printarray(join);
            return join;

        }

        static int indexofmin(int[] array, string evenodd)
        {
            int index = -1, min = int.MaxValue;
            if (evenodd == "even")
            {
                int i;
                for (i = 0; i < array.Length; i++) if (array[i] % 2 == 0 && array[i] <= min) { min = array[i]; index = i; }
            }
            else if (evenodd == "odd")
            {
                int i;
                for (i = 0; i < array.Length; i++) if (array[i] % 2 != 0 && array[i] <= min) { min = array[i]; index = i; }
            }
            return index;
        }

        static int indexofmax(int[] array, string evenodd)
        {
            int index = -1, max = int.MinValue;
            if (evenodd == "even")
            {
                int i;
                for (i = 0; i < array.Length; i++) if (array[i] % 2 == 0 && array[i] >= max) { max = array[i]; index = i; }
            }
            else if (evenodd == "odd")
            {
                int i;
                for (i = 0; i < array.Length; i++) if (array[i] % 2 != 0 && array[i] >= max) { max = array[i]; index = i; }
            }
            return index;
        }

        static int[] first(int[] array, string evenodd, int count)
        {
            int[] elements = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length && index < count; i++) if (evenodd == "even")
                {
                    if (array[i] % 2 == 0) { elements[index] = array[i]; index++; }
                }
                else if (evenodd == "odd")
                {
                    if (array[i] % 2 != 0) { elements[index] = array[i]; index++; }
                }
            return elements;
        }

        static int[] last(int[] array, string evenodd, int count)
        {
            int[] elements = new int[count];
            int index = 0;
            for (int i = array.Length - 1; i >= 0 && index < count; i--) if (evenodd == "even")
                {
                    if (array[i] % 2 == 0) { elements[count - index - 1] = array[i]; index++; }
                }
                else if (evenodd == "odd")
                {
                    if (array[i] % 2 != 0) { elements[count - index - 1] = array[i]; index++; }
                }
            //elements.Reverse();
            return elements;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] nums = input.Split();
            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i]);
            }

            input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "exchange":
                        {
                            break;
                        }
                    case "max":
                        {

                        }
                    case "min":
                        {

                        }
                    case "first":
                        {

                        }
                    case "last":
                        {

                        }
                    
                    default: break;
                }

            }
            // exchange(numbers, 2);
            Console.WriteLine(indexofmin(numbers, "even"));
            printarray(last(numbers, "odd", 2));


            Console.ReadKey();
        }
    }
}

