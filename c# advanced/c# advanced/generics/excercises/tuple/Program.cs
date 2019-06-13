using System;

namespace tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] personBEERInfo = Console.ReadLine().Split();
            string[] numbersInfo = Console.ReadLine().Split();


            string personName = $"{personInfo[0]} {personInfo[1]}";
            string personTown = personInfo[2];

            var person = new Tuple<string, string>(personName, personTown);

            string beerName = personBEERInfo[0];
            int liters = int.Parse(personBEERInfo[1]);

            var beer = new Tuple<string, int>(beerName, liters);

            int n1 = int.Parse(numbersInfo[0]);
            double n2 = double.Parse(numbersInfo[1]);

            var numbers = new Tuple<int, double>(n1, n2);
            Console.WriteLine($"{person.GetInfo()}\n{beer.GetInfo()}\n{numbers.GetInfo()}");


        }

    }
}
