using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace einstein_s_ridddle
{
    class Program
    {
        static string[] houses = { "Red", "Green", "Yellow", "White", "Blue" };
        static string[] pets = { "Dog", "Cat", "Bird", "Horse", "Fish" };
        static string[] nationalities = { "Brit", "Swede", "Dane", "Norwegian", "German" };
        static string[] ciggaretes = { "Blend", "Prince", "Dunhill", "BlueMaster", "Pullmall" };
        static string[] drinks = { "Tea", "Coffee", "Milk", "Beer", "Water" };
        static string[] hint = new string[15];

        static void swap(int i, int random, string[] array)
        {
            string temp = array[i];
            array[i] = array[random];
            array[random] = temp;
        }

        static void shuffle(Random rnd)
        {
            for(int i=0; i<5; i++){

                int randhouse = i + rnd.Next(0, houses.Length - i);
                swap(i, randhouse, houses);

                int randpet = i + rnd.Next(0, pets.Length - i);
                swap(i, randpet, pets);

                int randnat = i + rnd.Next(0, nationalities.Length - i);
                swap(i, randnat, nationalities);

                int randcig = i + rnd.Next(0, ciggaretes.Length - i);
                swap(i, randcig, ciggaretes);

                int randdrincc = i + rnd.Next(0, drinks.Length - i);
                swap(i, randdrincc, drinks);
            }
        }

        static void hints()
        {
            hints[0] = $"The {nationalities[2]} lives in the {houses[2]} house";
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            shuffle(rand);

            Console.WriteLine("Einstein's riddle:\n" +
                "The situation:\n" +
                "   1.There are 5 houses in five different colors.\n" +
                "   2.In each house lives a person with a different nationality.\n" +
                "   3.These five owners drink a certain type of beverage, smoke a certain brand of cigar and keep a certain type of pet.\n" +
                "   4.No owners have the same pet, smoke the same brand of cigar or drink the same beverage.");
            Console.WriteLine("The question is: Who owns the {0}", pets[3]);
            Console.WriteLine("Hints:");


            Console.ReadKey();
        }
    }
}
