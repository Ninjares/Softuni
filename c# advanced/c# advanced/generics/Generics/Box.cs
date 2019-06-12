using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class Box<T>
    {
        private List<T> boxItems;

        public int Count
        {
            get
            {
                return boxItems.Count;
            }
        }

        public Box()
        {
            boxItems = new List<T>();
        }

        public void Add(T item)
        {
            boxItems.Add(item);
        }
        public T Remove()
        {
            if (Count > 0)
            {
                T lastElement = boxItems[boxItems.Count - 1];
                boxItems.RemoveAt(Count - 1);
                return lastElement;
            }
            else throw new InvalidOperationException("Empty box, nothing to remove.");
        }
    }
}
