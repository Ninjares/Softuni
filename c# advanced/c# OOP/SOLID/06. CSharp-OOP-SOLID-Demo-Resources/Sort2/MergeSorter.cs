using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    class MergeSorter<T>:AbstractSorter<T>
    {
        public override IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Abstract sort");
            return collection;
        }
    }
}
