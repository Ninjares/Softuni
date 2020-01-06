using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class AbstractSorter<T>
    {
        public virtual IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("abstract");
            return collection;
        }
    }
}
