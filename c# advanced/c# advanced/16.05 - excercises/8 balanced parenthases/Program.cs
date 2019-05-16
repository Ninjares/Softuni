using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_balanced_parenthases
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] parenthases = Console.ReadLine().ToCharArray();
            Stack<char> openpars= new Stack<char>();
            Stack<char> expectedclosed = new Stack<char>();
            bool iscool = true;
            foreach(char par in parenthases)
            {
                if (par == '{' || par == '[' || par == '(')
                {
                    openpars.Push(par);
                    switch (par)
                    {
                        case '(':
                            {
                                expectedclosed.Push(')');
                                break;
                            }
                        case '{':
                            {
                                expectedclosed.Push('}');
                                break;
                            }
                        case '[':
                            {
                                expectedclosed.Push(']');
                                break;
                            }
                    }
                }
                else if (par == '}' || par == ']' || par == ')')
                {
                    if (par == expectedclosed.Peek()) expectedclosed.Pop();
                    else { iscool = false; break; }
                }
            }
            if (iscool) Console.WriteLine("YES");
            else Console.WriteLine("NO");
            Console.ReadKey();

        }
    }
}
