using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class Sorter<T>
    {
        public Sorter (string type)
        {
            ISorterStrategy<T> sorterStrategy = null;
            if(type == "merge")
            {
                sorterStrategy = new MergeSorter<T>();
            }
            else if(type == "selection")
            {
                this.SelectionSort(new List<T>());
            }
            else if(type == "bogo")
            {
                sorterStrategy = new BogoSort<T>();
                
            }
            sorterStrategy.Sort(new List<T>());
        }

        public IEnumerable<T> SelectionSort(IEnumerable<T> collection)
        {
            Console.WriteLine("Selection sort is da best");
            return collection;
        }

        public IEnumerable<T> MergeSort(IEnumerable<T> collection)
        {
            Console.WriteLine("Merge sort is da worst");
            return collection;
        }

        public IEnumerable<T> BubbleSort(IEnumerable<T> collection)
        {
            Console.WriteLine("Babbul sort is da worst");
            return collection;
        }

    }
}
