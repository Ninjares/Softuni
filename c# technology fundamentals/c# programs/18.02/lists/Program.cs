using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lists
{
    class Program
    {
        static List<int> readlist(int n)
        {
            List<int> list = new List<int>();
            for(int i=0; i<n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));

            }
            return list;
        }
        static void printintlist(List<int> a)
        {
            foreach(int num in a) Console.Write(num + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<string> newestmemes = new List<string>();
            newestmemes.Add("first meme");
            newestmemes.Add("Yeet");
            newestmemes.Add("traps are gay");

            foreach(string name in newestmemes) Console.WriteLine(name);
            Console.WriteLine(string.Join(", ", newestmemes));

            ////////////////////////////
            
            int[] array = { 1, 2, 4 };
            List<int> numbers = new List<int>(array);
            printintlist(numbers);
            Console.WriteLine("total: "+numbers.Count() +"\n");
            numbers.Add(-2);
            printintlist(numbers);
            Console.WriteLine("total: "+numbers.Count()+"\n"); //number of elements in the list
            numbers.Remove(4);              //remove the element stated in the brackets
            printintlist(numbers);
            numbers.RemoveAt(2);            //broqt se indexite v listovete kato v masivite
            printintlist(numbers);

            numbers.Add(1); numbers.Add(1); numbers.Add(1);
            printintlist(numbers);
            numbers.RemoveAll(x => x == 1);     //removes all numbers who fit the if statement
            printintlist(numbers);
            numbers.Insert(0, 15);              //inserts an element at the indicared index
            printintlist(numbers);
            Console.WriteLine(numbers.Contains(15)); //bool to check if an element is present in an index
            numbers[0] = 12;
            printintlist(numbers);
            numbers.Sort();            //sorts the list in an ascending order
            printintlist(numbers);

            List<string> names = new List<string>();
            names.Add("Ники");
            names.Add("Жоро");
            names.Add("Виктор");
            names.Add("Иво");
            names.Sort();
            Console.WriteLine(string.Join(" ", names));

            List<List<int>> list = new List<List<int>>();
            list.Add(new List<int>() { 1, 2, 3 });
            Console.WriteLine(list[0][2]);

            /*
            string values = Console.ReadLine();
            string[] splitv = values.Split();
            int[] intval = new int[values.Length];
            for(int i=0; i<values.Length; i++) */






            Console.ReadKey();


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
