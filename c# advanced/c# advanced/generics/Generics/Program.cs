using System;
using System.Linq;
using CustomStructures;

namespace Generics //A generic introduces the concept of a "type parameter" (TEMPLATES)
{
    class Program
    {
        #region
        public class CustomStacc<T>
        {
            T[] array = new T[5];
            public int Count { get; private set; }
            public CustomStacc()
            {

            }
            public void Add (T element)
            {

            }

            
        }

        class Nongeneric // can input anything; no safety; no intellisense
        {
            private object[] elements;
            public Nongeneric()
            {
                this.elements = new object[4];
            }
            public void Add(object value)
            {

            }
        }
        #endregion

        static void Main(string[] args)
        {
            string[] yeet = Console.ReadLine().Split()
                //.Select(int.Parse).ToArray()
                ;
           
            var test = new EqualityScale<string>(yeet[0], yeet[1]);
            Console.WriteLine(test.AreEqual());
            test.IsHeavier();

            CustomList<MyClass> comparethis = new CustomList<MyClass>();
        }
    }
}
