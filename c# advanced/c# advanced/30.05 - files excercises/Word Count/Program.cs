using System;
using System.IO;
namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string texttocheck = File.ReadAllText(@"..\..\..\Text\text.txt");
            string[] wordstocheck = File.ReadAllText(@"..\..\..\Text\words.txt").Split(new string[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(texttocheck + '\n' + string.Join(" ", wordstocheck));
        }
    }
}
