using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList<T> : List<T>
    {
        public T RandomElement()
        {
            Random random = new Random();
            int pos = random.Next(Count);
            Console.WriteLine("pos: "+pos);
            return this[pos];
        }
        public RandomList() : base()
        {

        }

        public RandomList(params T[] data) : base(data)
        {

        }
    }
}
