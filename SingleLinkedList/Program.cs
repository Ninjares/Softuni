using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> samplelist = new List<int>();

            SLList<int> list = new SLList<int>(new int[] {1,2,3,4,5} );
            list.Remove(2);
            Console.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine(list.Contains(3));
            Console.WriteLine(list.Contains(6));
            
           
            
        }
        
    }
}
