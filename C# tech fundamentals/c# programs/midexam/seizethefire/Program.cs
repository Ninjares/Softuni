using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seizethefire
{
    class fuckthisrpgbullshit
    { 
        static void printcells(List<int> a)
        {
            Console.WriteLine("Cells:");
            foreach (int n in a) Console.WriteLine(" - " + n);
        }
        static bool legitfire(string type, int value)
        {
        if (type == "Low" && value > 0 && value <= 50) return true;
        else if (type == "Medium" && value > 50 && value <= 80) return true;
        else if (type == "High" && value > 80 && value <= 125) return true;
        else return false;
        }

        static void Main(string[] args)
        {
            string firedetails = Console.ReadLine();
            int water = int.Parse(Console.ReadLine());
            
            string[] fires = firedetails.Split('#');
            List<int> cells = new List<int>();
            foreach(string cell in fires)
            {
                string[] typeandvalue = cell.Split(new string[] { " = " }, StringSplitOptions.None);
                if (legitfire(typeandvalue[0], int.Parse(typeandvalue[1])) && water >= int.Parse(typeandvalue[1]))
                {
                    cells.Add(int.Parse(typeandvalue[1]));
                    water -= int.Parse(typeandvalue[1]);
                }
            }
            decimal effort = 0m;
            int totalfire = 0;
            foreach (int fire in cells) { effort += (decimal)fire * 0.25m; totalfire += fire; }
            printcells(cells);
            Console.WriteLine($"Effort: {effort:F2}\nTotal Fire: {totalfire}");
            //Console.ReadKey();
        }
    }
}
