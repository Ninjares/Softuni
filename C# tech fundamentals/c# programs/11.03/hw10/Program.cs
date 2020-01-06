using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, int>();
            var plangs = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while(input!="exam finished")
            {
                
                string[] exam = input.Split('-');
                if (exam[1] == "banned")
                {
                    if (students.ContainsKey(exam[0])) students.Remove(exam[0]);
                }
                else
                {
                    if (!students.ContainsKey(exam[0]))
                        students.Add(exam[0], int.Parse(exam[2]));
                    else if (int.Parse(exam[2]) > students[exam[0]]) students[exam[0]] = int.Parse(exam[2]);
                    if (!plangs.ContainsKey(exam[1]))
                        plangs.Add(exam[1], 1);
                    else plangs[exam[1]]++;
                }
                input = Console.ReadLine();
            }

            students = students.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            plangs = plangs.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var stud in students) Console.WriteLine("{0} | {1}", stud.Key, stud.Value);
            Console.WriteLine("Submissions:");
            foreach (var sub in plangs) Console.WriteLine("{0} - {1}", sub.Key, sub.Value);
            Console.ReadKey();

        }
    }
}
