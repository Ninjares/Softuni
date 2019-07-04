using System;
using System.Collections.Generic;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> samplelist = new List<int>();
            
            SLList<int> list = new SLList<int>();

            Console.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
           
            
        }
        
    }
}
