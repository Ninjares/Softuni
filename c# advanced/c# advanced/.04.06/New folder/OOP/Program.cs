using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        class OOPfield
        {
            
            public string smallcase;   //field 
            public string Largecase;   //property                                                                                                                               it's ethics
            public int Length { get; } //if a variable has a get; set; it is definetely a property (wrench)
            public OOPfield()
            {
                Length = 7;
            }
        }

        public class Dice
        {
            private int sides;
            public int Sides
            {
                get { return this.sides; }      //this. (this class)
                set => this.sides = value;
            }

            private Random rnd = new Random();
            public int Roll()
            {
                return rnd.Next(1, this.Sides + 1);
            }

            public Dice(int sides)
            {
                Sides = sides;
            }
        }

        public class Car
        {
            private string make;
            private string model;
            private int age;
            private int fuel;
            private int FC = 8;
            public int Age { get { if (age > 3) return age - 1; else return age; } } 
            public int Fuel { get { return fuel; } }
            
            public Car()
            {
                make = "VW";
                model = "Golf";
                age = 2025;
                FC = 10;
                fuel = 200;
            }
        
            public Car(string model, int age, int fuel):this() // if you want an empty constructor create your own 
            {
                this.model = model;
                this.age = age;
                this.fuel = fuel;
            }

            public void Drive(double distance)
            {
                double consumedFuel= distance / 100 * FC;
                if (consumedFuel > fuel)
                {
                    throw new ArgumentException("Load up on guzzoline");
                }
                else fuel -= (int) consumedFuel;
            }
        }

        static void Main(string[] args)
        {
            Dice dice = new Dice(6);
            for (int i = 0; i < 50; i++) Console.WriteLine(dice.Roll());
            Console.WriteLine();

            Car mycar = new Car("blu", 1, 10);
            mycar.Drive(100);
            Console.WriteLine(mycar.Fuel);
            


            
        }
    }
}
