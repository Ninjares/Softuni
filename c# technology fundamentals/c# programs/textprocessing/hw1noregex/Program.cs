using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1noregex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i<names.Length; i++)
            {
                string name = names[i];
                bool isValid = false;
                if (name.Length > 2 && name.Length < 17)
                {
                    for(int j=0; j < name.Length; j++)
                    {
                        char currentChar = name[j];
                        if (char.IsLetterOrDigit(currentChar) || currentChar == '-' || currentChar == '_') isValid = true;
                        else { isValid = false; break; }
                    }
                }
                if (isValid) Console.WriteLine(name);
            }


            Console.ReadKey();

        }
    }
}
