using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ranking
{
    class Program
    {
        static void Main(string[] args)
        {            //student           contest result
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
                     //contest pass
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input!="end of contests")
            {
                string[] contest = input.Split(':');
                if (!contests.ContainsKey(contest[0])) contests.Add(contest[0], contest[1]);
                input = Console.ReadLine();
            }
            while(input!="end of submissions")
            {
                string[] submission = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                if (contests.ContainsKey(submission[0])&&input!="end of submissions")
                    if(contests[submission[0]] == submission[1])
                {
                    if (!students.ContainsKey(submission[2])) students.Add(submission[2], new Dictionary<string, int>());
                    if (!students[submission[2]].ContainsKey(submission[0])) students[submission[2]].Add(submission[0], int.Parse(submission[3]));
                    else if (int.Parse(submission[3]) > students[submission[2]][submission[0]]) students[submission[2]][submission[0]] = int.Parse(submission[3]);
                }
                input = Console.ReadLine();
            }

            string beststudent = "";
            int mostpoints = 0;
            foreach(var student in students)
            {
                int points = 0;
                foreach (var score in student.Value) points += score.Value;
                if(points>mostpoints) { mostpoints = points; beststudent = student.Key; }
            }
            Console.WriteLine($"Best candidate is {beststudent} with total {mostpoints} points.\nRanking: ");
            students = students.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach(var student in students)
            {
                Console.WriteLine($"{student.Key}");
                foreach(var subject in student.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value))
                {
                    Console.WriteLine($"#  {subject.Key} -> {subject.Value}");
                }
            }
            Console.ReadKey();
        }
    }
}
