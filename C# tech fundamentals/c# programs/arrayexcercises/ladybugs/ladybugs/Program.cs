using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldsize = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] indexess = input.Split();
            int[] indexes = Array.ConvertAll(indexess, int.Parse);
            int[] field = new int[fieldsize];
            foreach (int num in indexes) if (num >= 0 && num < field.Length) field[num] = 1;
        //    foreach (int spot in field) Console.Write(spot + " | ");
        //    Console.WriteLine();
            input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                int fieldindex = int.Parse(command[0]);
                int moves = int.Parse(command[2]);
                if (fieldindex >= 0 && fieldindex < field.Length)
                {
                    if (field[fieldindex] == 1)
                    {
                        int goalindex = 0;
                        if (moves >= 0)
                        {
                            if (command[1] == "left") goalindex = fieldindex - moves;
                            else if (command[1] == "right") goalindex = fieldindex + moves;
                        }
                        else
                        {
                            if (command[1] == "left") { command[1] = "right"; goalindex = fieldindex - moves; }
                            else if (command[1] == "right") { command[1] = "left"; goalindex = fieldindex + moves; }
                        }



                        int goaltype = 0; //0-clear 1-outside 2-ladybug
                        if (goalindex < 0 || goalindex >= field.Length) goaltype = 1;
                        else
                        {
                            if (field[goalindex] == 1) goaltype = 2;
                            while (goaltype == 2)
                            {
                                if (field[goalindex] == 1 && command[1] == "left") goalindex--;
                                else if (field[goalindex] == 1 && command[1] == "right") goalindex++;
                                if (goalindex < 0 || goalindex >= field.Length) goaltype = 1;
                                else if (field[goalindex] == 0) goaltype = 0;
                            }
                        }
                        if (goalindex < 0 || goalindex >= field.Length) field[fieldindex] = 0;
                        else { field[fieldindex] = 0; field[goalindex] = 1; }
                    }

                }
             //   foreach (int spot in field) Console.Write(spot + " | ");
             //       Console.WriteLine(); 
                input = Console.ReadLine();
            }
            foreach (int spot in field) Console.Write(spot + " ");
          //  Console.ReadKey();
        }
    }
}

