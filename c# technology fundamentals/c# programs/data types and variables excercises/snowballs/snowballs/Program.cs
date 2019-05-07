using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double highestsnowballvalue = 0;
            int hsbsnow = 0;
            int hsbtime = 0;
            int hsbquality = 0;
            for (int i=0; i<n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                double snowballValue = Math.Pow(((double)snowballSnow/snowballTime), snowballQuality);
                //Console.WriteLine("{0} : {1} = {2} ({3})", snowballSnow, snowballTime, snowballValue, snowballQuality);
                if (highestsnowballvalue < snowballValue)
                {
                    highestsnowballvalue = snowballValue;
                    hsbsnow = snowballSnow;
                    hsbtime = snowballTime;
                    hsbquality = snowballQuality;
                }        
            }
            if(n!=0)
            Console.WriteLine("{0} : {1} = {2} ({3})", hsbsnow, hsbtime, highestsnowballvalue, hsbquality);
            Console.ReadKey(); 
        }
    }
}
