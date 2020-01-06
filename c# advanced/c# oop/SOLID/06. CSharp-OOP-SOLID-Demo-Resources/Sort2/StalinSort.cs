using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class BogoSort<T> : AbstractSorter<T>
    {
        public override IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Bogo bogo bogo");
            return collection;
        }
    }
}
