using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Program
    {   
        
        /*
        static int[] inputtoarray(string input)
        {
            string[] split = input.Split();
            int[] retarray = new int[split.Length];
            for (int i = 0; i < split.Length; i++) retarray[i] = int.Parse(split[i]);
            return retarray;
        }

        static List<int> arraytolist(int[] array)
        {
            List<int> returnlist = new List<int>();
            foreach (int el in array) returnlist.Add(el);
            return returnlist;
        }
        */
        
        static void Main(string[] args)
        {
            int noofcommands = int.Parse(Console.ReadLine());
            List<string> people = new List<string>();
            for(int i=0; i<noofcommands; i++)
            {
                string input = Console.ReadLine();
                string[] sentence = input.Split();
                if (sentence[2] == "going!")
                {
                    if (people.Contains(sentence[0])) Console.WriteLine("{0} is already in the list!", sentence[0]);
                    else people.Add(sentence[0]);
                }
                else if (sentence[2] == "not")
                {
                    if (people.Contains(sentence[0])) people.Remove(sentence[0]);
                    else Console.WriteLine("{0} is not in the list!", sentence[0]);
                }

            }
            
            foreach (string person in people) Console.WriteLine(person);
            
            

            Console.ReadKey();
            
        }
    }
}
