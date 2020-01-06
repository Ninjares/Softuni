using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymoose
{
    class Program
    {
        static List<string> merge(List<string> inlist, int startindex, int endindex)
        {
            List<string> returnlist = new List<string>();
            int i = 0;
            for (i = 0; i < startindex; i++) returnlist.Add(inlist[i]);
            string merge = "";
            for (i = startindex; i <= endindex; i++) merge += inlist[i];
            returnlist.Add(merge);
            for (i = endindex + 1; i < inlist.Count; i++) returnlist.Add(inlist[i]);
            return returnlist;
        }
        static List<string> divide(List<string> inlist, int index, int partions)
        {
            string splitter = inlist[index];

            inlist.RemoveAt(index);
            int piecesize = splitter.Length / partions;
            int cycle = 0;
            for (int i = index; i < index + partions; i++)
            {
                string toadd = "";
                for (int j=0; j < piecesize; j++) toadd += splitter[j+cycle*piecesize]; cycle++;

                inlist.Insert(i, toadd);
            }
            if (cycle * piecesize != splitter.Length) for (int i = cycle * piecesize; i < splitter.Length; i++) inlist[index + cycle - 1] += splitter[i]; 
            return inlist;
        }

        static void Main(string[] args)
        {
            List<string> setofstrings = Console.ReadLine().Split().ToList();
           // Console.WriteLine(string.Join("\n", setofstrings));
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "3:1")
            {
                switch (commands[0])
                {
                    case "merge":
                        {
                            int start = int.Parse(commands[1]), end = int.Parse(commands[2]);
                            if (start < 0) start = 0;
                            if (end >= setofstrings.Count) end = setofstrings.Count - 1;
                            if (start >= end) start = end - 1;
                            if (start < 0) start = 0;
                            setofstrings = merge(setofstrings, start, end);
                          //  Console.WriteLine(string.Join("\n", setofstrings));
                            break;
                        }
                    case "divide":
                        {
                            int index = int.Parse(commands[1]), partions = int.Parse(commands[2]);
                            if (index < 0) index = 0;
                            if (index >= setofstrings.Count) index = setofstrings.Count - 1;

                            setofstrings = divide(setofstrings, index, partions);
                           // Console.WriteLine(string.Join("\n", setofstrings));
                            break;
                        }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", setofstrings));
          //Console.ReadKey();
           
        }
    }
}
