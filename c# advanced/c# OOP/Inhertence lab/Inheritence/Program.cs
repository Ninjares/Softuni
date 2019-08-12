using System;

namespace Inheritence
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee somedude = new Employee("Tashi", "Surbac st.", "Hesmurger");
            Console.WriteLine(somedude.Address);
        }
    }
}
