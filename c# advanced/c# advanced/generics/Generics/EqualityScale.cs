using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class EqualityScale<T>where T: IComparable
    {
        public T left;
        public T right;

        public EqualityScale(T l, T r)
        {
            this.left = l;
            right = r;
        }

        public bool AreEqual()
        {
            return left.CompareTo(right) == 0;
            //if (left == right) return true;
            //else return false;
        }
        
        public void IsHeavier()
        {
            int result = left.CompareTo(right);     // if it's comparing classes, structs, arrays(referentials) it uses a referencial comparer (pointer) 
            if (result == 0) Console.WriteLine("Equal");
            else if (result < 0) Console.WriteLine("Right is heavier");
            else if (result > 0) Console.WriteLine("Left is heavier");
        }
    }
}
