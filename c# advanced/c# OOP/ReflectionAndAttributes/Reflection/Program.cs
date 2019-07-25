using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //avoid reflection - it be slow af and insecure
            //Reflection API -
            //   -Type class
            //   -Reflecting fiels, constructors and methods
            //Attributes

            //Metaprogramming - a program can treat other programs as data
            //Reflection - a program to treat itself as data (in its own language)
            //Reflection - to use when: we want more extendable code, reduce code length, easier maintenance and testing
            //GetType();
            List<int> somelist = new List<int>();
            Console.WriteLine(typeof(List<int>).FullName);
            Console.WriteLine(typeof(List<int>).Name);
            Type sometype = Type.GetType(typeof(List<int>).FullName);
            Console.WriteLine(typeof(Student).FullName);
            Console.WriteLine(typeof(Student).Name);
            Console.WriteLine(typeof(Student).BaseType);

            Type studentType = typeof(Student);
            Type[] interfaces = studentType.GetInterfaces();
            Student pesho = (Student)Activator.CreateInstance(studentType, new object[] { "Name", 15 });
            var constructors = studentType.GetConstructors();
            MethodInfo method = studentType.GetMethod("print");
            method.Invoke(pesho, new object[] { "yeet" });
            
            Console.ReadKey();
        }

        //Atttributes
        //
        //[Required]
        //public int SomeDataForTable {get;set;}
        //[Key]
        //public int Id {get; set;}

    }
}
