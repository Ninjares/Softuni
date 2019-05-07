using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayrotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] array = input.Split();
            int n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                string[] replace = new string[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    if (j == array.Length-1) replace[j] = array[0];
                    else
                        replace[j] = array[j+1];
                }
                array = replace;
            }
                
            foreach (string s in array) Console.Write(s + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
