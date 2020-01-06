using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class BogoSort<T> : ISorterStrategy<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Bogo bogo bogo");
            return collection;
        }
    }
}
