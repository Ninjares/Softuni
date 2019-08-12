using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] spizza = Console.ReadLine().Split();
            string[] sdough = Console.ReadLine().Split();
            Pizza pizza = new Pizza(spizza[1]);
            Dough dough = new Dough(int.Parse(sdough[3]), sdough[1], sdough[2]);
            pizza.Dough = dough;
            string input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    string[] stopping = input.Split();
                    pizza.AddTopping(new Topping(int.Parse(stopping[2]), stopping[1]));
                    input = Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(pizza.ToString());
        }
    }
}
