using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listofints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int specialnum = nums[0], power = nums[1];
            
            for(int i=0; i<listofints.Count; i++)
                if (listofints[i] == specialnum)
                {
                    //remove right
                    for (int j = 1; j <= power; j++) if (i + j >= listofints.Count) break; else listofints[i + j] = 0 ;
                    //remove left
                    for (int j = 1; j <= power; j++) if (i - j < 0) break;
                        else listofints[i - j] = 0;
                    listofints[i]=0;
                }
            int sum=0;
            foreach (int i in listofints) {
            //    Console.Write(i + " ");
                sum += i; }
            Console.WriteLine("\n" + sum);
          //  Console.ReadKey();
        }
    }
}
