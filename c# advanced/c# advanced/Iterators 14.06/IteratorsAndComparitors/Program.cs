using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Book one = new Book("Sumbocc", 2019, "Dankata");
            Book two = new Book("Sumotherbocc", 2020, "Dankata", "Benisa");
            Book three = new Book("Sumbo", 1930);
            
            foreach (var author in two.Authors) Console.WriteLine($"{author}");

            var libraryEmpty = new Library();
            var library = new Library(one, two, three);
            foreach(var book in library)
            {
                Console.WriteLine($"{book.Title} - {book.Year}");
            }
        }
    }
}
