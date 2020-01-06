using System;

namespace Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractSorter<int> sorter = new MergeSorter<int>();
            sorter.Sort(new int[] { });
            sorter = new BogoSort<int>();
            sorter.Sort(new int[] { });
        }
    }
}
