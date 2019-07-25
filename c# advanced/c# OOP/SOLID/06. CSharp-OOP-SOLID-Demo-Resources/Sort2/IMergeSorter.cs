using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    class IMergeSorter<T> : ISorterStrategy<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Merge sort is da vurst");
            return collection;
        }
    }
}
