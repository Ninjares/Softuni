using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace associative_arrays
{
    class Program
    {
        class keyvalue
        {
            public string key;
            public int val;

            public keyvalue(string s, int v)
            {
                key = s;
                val = v;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, char> assarray = new Dictionary<string, char>(); //figure out how the hash function and memory allocation works
                                                                                //hash creates an integer value and uses the remainder of said value to allocate the location within the array
            SortedDictionary<string, char> sortass = new SortedDictionary<string, char>();
            //keys are always sorted (like maps?)
            //Used a balanced search tree for 1000 elements 10 steps
            List<keyvalue> bois = new List<keyvalue>();

            assarray.Add("Gosho", 'G');
            assarray.Add("Mojo", 'M');
            assarray.Add("Benis", 'B');
            sortass.Add("Gosho", 'G');
            sortass.Add("Mojo", 'M');
            sortass.Add("Benis", 'B');
            bois.Add(new keyvalue("Gosho", 2));
            bois.Add(new keyvalue("Mojo", 3));
            bois.Add(new keyvalue("Benis", 4));

            if (assarray.ContainsKey("Gosho")) Console.WriteLine($"gosho key exists");
            assarray.Sort();
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
