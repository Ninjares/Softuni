using System;
using System.Collections.Generic;
using System.Linq;

namespace party_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split();
            List<string> filters = new List<string>();
            string filter = Console.ReadLine();
            while (filter != "Print")
            {
                string[] filterInfo = filter.Split(';');
                if (filterInfo[0] == "Add filter") filters.Add($"{filterInfo[1]}:{filterInfo[2]}");
                else if (filterInfo[0] == "Remove filter") filters.Remove($"{filterInfo[1]}:{filterInfo[2]}");
                filter = Console.ReadLine();
            }
            Func<string, string, bool> StartsWith = (name, param) => name.StartsWith(param);
            Func<string, string, bool> EndsWith = (name, param) => name.EndsWith(param);
            Func<string, string, bool> Contains = (name, param) => name.Contains(param);
            Func<string, int, bool> Length = (name, param) => name.Length==param;

            foreach(string filtr in filters)
            {
                string[] prms = filtr.Split(':');
                string filterType = prms[0];
                switch (filterType)
                {
                    case "Starts with":
                        {
                            people = people.Where(x => !StartsWith(x, prms[1])).ToArray();
                            break;
                        }
                    case "Ends with":
                        {
                            people = people.Where(x => !EndsWith(x, prms[1])).ToArray();
                            break;
                        }
                    case "Contains":
                        {
                            people = people.Where(x => !Contains(x, prms[1])).ToArray();
                            break;
                        }
                    case "Length":
                        {
                            people = people.Where(x => !Length(x, int.Parse(prms[1]))).ToArray();
                            break;
                        }
                }
            }
            Console.WriteLine(string.Join(' ', people));

        }
    }
}
