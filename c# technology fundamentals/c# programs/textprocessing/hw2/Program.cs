using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            //(str0charsum + str1charsum)*str00*str10
            string[] str = Console.ReadLine().Split();
            string shortword = string.Empty;
            string longword = string.Empty;
            if (str[0].Length < str[1].Length)
            {
                longword = str[1];
                shortword = str[0];
            }
            else
            {
                longword = str[0];
                shortword = str[1];
            }
            int totalsum = 0;
            for (int i=0; i<longword.Length; i++)
            {
                if (i < shortword.Length)
                {
                    totalsum += (int)shortword[i] * (int)longword[i];
                }
                else totalsum += (int)longword[i];
            }
            Console.WriteLine(totalsum);
            Console.ReadKey(); 
        }
    }
}
