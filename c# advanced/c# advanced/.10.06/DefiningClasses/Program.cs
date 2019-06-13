using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Person[] opinions = new Person[n];
            for(int i=0; i<n; i++)
            {
                string[] newperson = Console.ReadLine().Split();
                opinions[i] = new Person(newperson[0], int.Parse(newperson[1]));
            }

            opinions = opinions.Where(x => x.Age > 30).OrderBy(x => x.Name).ToArray();

            foreach(Person oldie in opinions)
            {
                Console.WriteLine($"{oldie.Name} - {oldie.Age}");
            }


        }
    }
}