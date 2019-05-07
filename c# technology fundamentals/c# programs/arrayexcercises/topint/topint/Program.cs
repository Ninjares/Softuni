using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topint
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] ins = input.Split();
            int[] topints = new int[ins.Length];
            for(int i=0; i<topints.Length; i++)
                topints[i] = int.Parse(ins[i]);
            int index = -1;
          /*    if (topints.Length % 2 == 0)
              {
                  for (int split = 0; split < topints.Length; split++)
                  {
                      int sumleft = 0, sumright = 0;
                      for (int l = 0; l <= split; l++) sumleft += topints[l];
                      for (int r = split + 1; r < topints.Length; r++) sumright += topints[r];
                      if (sumleft == sumright) equalsums++;
                  }
              }
              else */
            {
                for (int split = 0; split < topints.Length; split++)
                {
                    int sumleft = 0, sumright = 0;
                    for (int l = 0; l < split; l++) sumleft += topints[l];
                    for (int r = split + 1; r < topints.Length; r++) sumright += topints[r];
                    if (sumleft == sumright) index = split;

                }
            }
                if (index == -1) Console.WriteLine("no");
                else Console.WriteLine(index);
            Console.ReadKey();
        }
    }
}
