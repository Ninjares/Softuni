using System;

namespace tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ', 4);
            string[] personBEERInfo = Console.ReadLine().Split();
            string[] bankInfo = Console.ReadLine().Split();

            var person = new Tuple<string, string, string>($"{personInfo[0]} {personInfo[1]}", personInfo[2], personInfo[3]);
            var beer = new Tuple<string, int, bool>(personBEERInfo[0], int.Parse(personBEERInfo[1]), personBEERInfo[2] == "drunk");
            var bank = new Tuple<string, double, string>(bankInfo[0], double.Parse(bankInfo[1]), bankInfo[2]);

            Console.WriteLine(person.GetInfo());
            Console.WriteLine(beer.GetInfo());
            Console.WriteLine(bank.GetInfo());


        }

    }
}
