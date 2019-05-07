using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string result = new string(new char[] { 'H', 'i', '!', '\n' });
            char[] print = result.ToCharArray();
            Console.WriteLine(print);

            string greet = "Hello, ";
            string name = "My n1884";
            Console.WriteLine(string.Concat(greet, name, "!"));


            string fruits = "banana, apple, kiwi, banana, apple";
            Console.WriteLine(fruits.IndexOf("banana"));
            Console.WriteLine(fruits.IndexOf("orange"));
            Console.WriteLine(fruits.LastIndexOf("banana")); //returns the startinf index of it
            Console.WriteLine(fruits.LastIndexOf("orange")); //-1 means it cycled to the start

            Console.WriteLine(fruits.Contains("banana"));
            Console.WriteLine(fruits.Contains("ana, "));
            Console.WriteLine(fruits.Contains("shit"));

            string text = "My name is John";
            Console.WriteLine(text.Substring(3, 4));    //from index till length or 
            Console.WriteLine(text.Substring(3));
            Console.WriteLine(text.Substring(11));

            StringBuilder sb = new StringBuilder(); //can be used to change individual chars
            sb.Append("Hello"); //adds text to the first free space
            sb.Append("Peter!");
            sb.Insert(5, ", ");
            sb.Replace("Peter", "Pesho"); //works on regular strings too
            Console.WriteLine(sb);
            sb.Clear();


            //Regex.Matches
            //using System.Text.RegularExpressions;
            //[nvj] - look got n, v, j
            //[^abc] - look for anything except a,b,c
            //[0-9] - look for 0 to 9
            //w - word charecter (a-z, A-Z, 0-9, _)
            //W - non-word charecter
            //s - white-space char
            //S - non-white space char
            //d - decimal digit
            //D - not a decimal digit

            Console.ReadKey();

        }
    }
}
