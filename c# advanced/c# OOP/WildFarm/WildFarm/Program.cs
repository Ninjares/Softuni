using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {
        static IFood ReturnFood(string[] commands)
        {
            IFood food = null;
            int quantity = int.Parse(commands[1]);
            switch (commands[0])
            {

                case "Vegetable":
                    {
                        food = new Vegetable(quantity);
                        break;
                    }
                case "Fruit":
                    {
                        food = new Fruit(quantity);
                        break;
                    }
                case "Meat":
                    {
                        food = new Meat(quantity);
                        break;
                    }
                case "Seeds":
                    {
                        food = new Seeds(quantity);
                        break;
                    }
            }
            return food;
        }

        static IAnimal ReturnAnimal(string[] commands)
        {
            IAnimal animal = null;
            string name = commands[1];
            double weight = double.Parse(commands[2]);
            switch (commands[0])
            {
                case "Cat":
                    {
                        animal = new Cat(name, weight, 0, commands[3], commands[4]);
                        break;
                    }
                case "Tiger":
                    {
                        animal = new Tiger(name, weight, 0, commands[3], commands[4]);
                        break;
                    }
                case "Mouse":
                    {
                        animal = new Mouse(name, weight,0, commands[3]);
                        break;
                    }
                case "Dog":
                    {
                        animal = new Dog(name, weight, 0, commands[3]);
                        break;
                    }
                case "Hen":
                    {
                        animal = new Hen(name, weight,0, double.Parse(commands[3]));
                        break;
                    }
                case "Owl":
                    {
                        animal = new Owl(name, weight, 0, double.Parse(commands[3]));
                        break;
                    }
            }

            return animal;
        }
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                IAnimal animal = ReturnAnimal(commands);
                Console.WriteLine(animal.Sound());
                commands = Console.ReadLine().Split();
                IFood food = ReturnFood(commands);
                try
                {
                    animal.Eat(food);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animals.Add(animal);
                input = Console.ReadLine();
            }
            foreach (var animal in animals) Console.WriteLine(animal);
        }
    }
}
