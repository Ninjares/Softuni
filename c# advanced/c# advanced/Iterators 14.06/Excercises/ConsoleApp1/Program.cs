using System;
using System.Collections.Generic;

namespace ListyIterator
{
    class ListyIterator<T>
    {
        private List<T> innerList;

        public int Iterator { get; set; }
        public ListyIterator(params T[] param)
        {
            innerList = new List<T>(param);
        }
        public void Move()
        {
            if (HasNext(Iterator)) Iterator++;
        }

        public bool HasNext(int index)
        {
            if (index + 1 < innerList.Count) return true;
            else return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
