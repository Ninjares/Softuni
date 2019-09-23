using System;
using System.Linq;

namespace Searchyb0is
{
    class Program
    {
        static int LinearSearch(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element) return i;
            return -1;
        }

        static int BinarySearchR(int[] array, int find, int start, int end) //sorted only
        {
            if (end < start) return -1;
            else
            {
                int mid = (start + end) / 2;
                if (array[mid] > find)
                    return BinarySearchR(array, find, start, mid - 1);
                else if (array[mid] < find)
                    return BinarySearchR(array, find, mid + 1, end);
                else return mid;
            }
        }
        static int InterpolationSearch(int[] sortedArray, int key)
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            while (sortedArray[low] <= key && sortedArray[high] >= key)
            {
                int mid = low + ((key - sortedArray[low]) * (high - low))
                / (sortedArray[high] - sortedArray[low]);
                if (sortedArray[mid] < key)
                    low = mid + 1;
                else if (sortedArray[mid] > key)
                    high = mid - 1;
                else
                    return mid;
            }
            if (sortedArray[low] == key) return low;
            else return -1;

        }
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int find = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearchR(numbers, find, 0, numbers.Length)); //index
            Console.WriteLine(InterpolationSearch(numbers, find));
        }
    }
}
