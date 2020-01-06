using System;
using System.Text;

namespace RandomClassWork
{
    class Program
    {
        static void FeedTheAnimal(IAnimal animal)
        {
            animal.Eat();
        }

        const int max = 10;
        class Person
        {

        }
        //Polymorphism - an object that can take many forms
        //Pri dynamic nqma intellisense (zabravi q, vika prepodavatela)
        static void Main(string[] args)
        { 
        Person person = new Person();

            //object   class
            Console.WriteLine(person is Person);
            //if (person is Person) ;

            //is is used for pattern matching

            int i = 0;
            while (true)
            {
                i++;
                if (i is max) break;
                Console.WriteLine(i);
            }
            //as operator
            //Student student = animal as Student;
            //check circles from interface lab
            var cat = new Cat();
            var dog = new Dog();
            Mammal mammal = new Mammal();
            FeedTheAnimal(cat);
            FeedTheAnimal(dog);
            FeedTheAnimal(mammal);
            

        }
    }
}
