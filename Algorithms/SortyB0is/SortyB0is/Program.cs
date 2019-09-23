using System;
using System.Collections.Generic;
using System.Linq;

namespace SortyB0is
{
    class Program
    {
        static void swap(ref int a, ref int b)
        {
            int help = a;
            a = b;
            b = help;
        }


        static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[i])
                        swap(ref array[j], ref array[i]);
            return array;
        }

        static int[] BubbleSort(int[] array)
        {
            int lastUE = array.Length;
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < lastUE - 1; i++)
                    if (array[i] > array[i + 1])
                    { swap(ref array[i], ref array[i + 1]); swapped = true; }
            }
            return array;

        }
        static int[] InsertionSort(int[] array)
        {
            for(int i=1; i<array.Length; i++)
            {
                bool sorted = false;
                for (int j = i; !sorted && j > 0; j--)
                    if (array[j] < array[j - 1]) swap(ref array[j], ref array[j - 1]);
                    else sorted = true;
            }
            return array;
        }

        static int[] merge(int[] leftArray, int[] rightArray)
        {
            int[] returnArray = new int[leftArray.Length + rightArray.Length];
            int atIndex = 0;
            Stack<int> la = new Stack<int>(leftArray.Reverse());
            Stack<int> ra = new Stack<int>(rightArray.Reverse());
            while (la.Count != 0 && ra.Count != 0)
            {
                if (la.Peek() < ra.Peek())  returnArray[atIndex++]=la.Pop(); 
                else  returnArray[atIndex++] = ra.Pop(); 
            }
            while (la.Count != 0)  returnArray[atIndex++] = la.Pop();
            while (ra.Count != 0)  returnArray[atIndex++] = ra.Pop();
            return returnArray;
        }
        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1) return array;

            int[] leftArray = new int[array.Length/2];
            int[] rightArray = new int[array.Length - array.Length / 2];
            Array.Copy(array, 0, leftArray, 0, array.Length / 2);
            Array.Copy(array, array.Length/2, rightArray, 0, array.Length - array.Length / 2) ;
            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);
            return merge(leftArray, rightArray);
        }

        static int[] QuickSort(int[] array, int pivot, int rightMostIndex)
        {
            if (pivot >= rightMostIndex) return null;
            int storeIndex = pivot + 1;
            for (int i = pivot + 1; i < rightMostIndex; i++)
            {
                if (array[i] < array[pivot])
                {
                    if (array[i] != array[storeIndex])
                    {
                        swap(ref array[i], ref array[storeIndex]);
                    }
                    storeIndex++;
                }
            }
            swap(ref array[pivot], ref array[--storeIndex]);
            QuickSort(array, pivot, storeIndex);
            QuickSort(array, storeIndex + 1, rightMostIndex);
            return array;
        }



        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", QuickSort(array, 0, array.Length)));
        }
    }
}
