using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacksnmaybequeues
{
    class Program
    {
        static void Main(string[] args)
        {
            //push
            //pop
            //peak = {x = pop(); push(x);}
            Stack<char> stacc = new Stack<char>();
            string sth = "I love C#";
            Console.WriteLine(sth);
            foreach (char a in sth) stacc.Push(a);

            //stacc.count - number of elements in stakcs
            Console.WriteLine(stacc.Contains('#'));
            while (stacc.Count != 0) Console.Write(stacc.Pop());
            Console.WriteLine(stacc.Contains('#'));
            Console.WriteLine("\nLIFO - last in first out\n");
            //stack.Clear(); - empties the stack
            //stack.TrimExcess() - fixes capacity if too much shit has been popped


            Queue<int> qu = new Queue<int>();
            for (int i = 1; i <= 10; i++) qu.Enqueue(i);
            Console.WriteLine(qu.Peek()); //peeks the tail
            
            while (qu.Count != 0) Console.Write($"{qu.Dequeue()} ");
            //.contains() and .count(), you know how it works
            //.ToArray()
            Console.WriteLine("FIFO - first in first out");
            
            
            Console.ReadKey();
        }
    }
}
