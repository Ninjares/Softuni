using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    enum ToppingType { Meat, Veggies, Cheese, Sauce}
    class Topping
    {
        private int grams;
        private ToppingType topping;
        private int Grams
        {
            get => grams;
            set
            {
                if (value < 1 || value > 50) { throw new Exception($"{topping} weight should be in the range [1..50]");}
                else grams = value;
            }
        }
        public decimal Calories
        {
            get
            {
                decimal cals = Grams * 2;
                switch (topping)
                {
                    case ToppingType.Cheese:
                    {
                            cals*= 1.1m;
                            break;
                    }
                    case ToppingType.Veggies:
                        {
                            cals*= 0.8m;
                            break;
                        }
                    case ToppingType.Sauce:
                        {
                            cals *= 0.9m;
                            break;
                        }
                    case ToppingType.Meat:
                        {
                            cals*= 1.2m;
                            break;
                        }

                }
                return cals;
            }
        }
        public Topping(int grams, string topping)
        {
            
            switch (topping.ToLower())
            {
                case "meat": { this.topping = ToppingType.Meat;  break; }
                case "veggies": { this.topping = ToppingType.Veggies; break; }
                case "cheese": { this.topping = ToppingType.Cheese; break; }
                case "sauce": { this.topping = ToppingType.Sauce; break; }
                default: { throw new Exception($"Cannot place {topping} on top of your pizza."); break; }
            }
            Grams = grams;
        }

        

       
    }
}
