using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<object>();
            string animal = Console.ReadLine();
            while (animal != "Beast!")
            {
                   if (!(animal == "Cat" || animal == "Dog" || animal == "Frog" || animal == "Kittens" || animal == "Tomcat")) Console.WriteLine("Invalid input!");
                   else
                      {
                      string[] animalProperties = Console.ReadLine().Split();
                        if (animalProperties[0] == "" || animalProperties[1] == "" || (int.Parse(animalProperties[1]) < 0))
                                Console.WriteLine("Invalid input!");
                        else
                        {
                            string name = animalProperties[0];
                            int age = int.Parse(animalProperties[1]);
                            string gender = animalProperties[2];
                            switch (animal)
                            {
                                case "Cat":
                                    {
                                        var cat = new Cat(name, age, gender);
                                        animals.Add(cat);
                                        break;
                                        }
                                case "Dog":
                                    {
                                        var dog = new Dog(name, age, gender);
                                        animals.Add(dog);
                                        break;
                                    }
                                case "Frog":
                                    {
                                        var frog = new Frog(name, age, gender);
                                        animals.Add(frog);
                                        break;
                                    }
                                case "Tomcat":
                                    {
                                        var tomcat = new Tomcat(name, age);
                                        animals.Add(tomcat);
                                    break;
                                    }
                                case "Kittens":
                                    {
                                        var kitten = new Kitten(name, age);
                                        animals.Add(kitten);
                                        break;
                                    }
                            }
                        }
                   }
                animal = Console.ReadLine();
            }
            foreach(var animl in animals)
            {
                Console.WriteLine();
                Console.WriteLine(animl);
                Console.WriteLine(animal.ProduceSound());
            }
        
        }
    }
}
