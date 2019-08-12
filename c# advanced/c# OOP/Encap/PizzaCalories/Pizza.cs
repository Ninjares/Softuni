using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Dough Dough { get => dough;  set => dough = value; }
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value.Trim() == "") { Console.WriteLine("Pizza name cannot be emtpy"); Environment.Exit(0); }
                else if (value.Length < 1 || value.Length > 15) {Console.WriteLine("Pizza name should be between 1 and 15 symbols."); Environment.Exit(0); }
                else name = value;

            }
        }
        public int NumberOfTopping { get => toppings.Count; }
        public decimal TotalCalories { get => toppings.Sum<Topping>(x => x.Calories) + dough.Calories; }

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count <= 10) toppings.Add(topping);
            else { Console.WriteLine("Number of toppings should be in range [0..10]."); Environment.Exit(0); }
        }
        public override string ToString()
        {
            return $"{Name} - {TotalCalories} Calories.";
        }

       

    }
}
