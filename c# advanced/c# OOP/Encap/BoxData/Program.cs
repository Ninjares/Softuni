using System;

namespace BoxData
{
    public class StartUp
    {
        static bool pass(double l, double w, double h)
        {
            bool passr = true;
            if (l < 0) { Console.WriteLine("Length cannot be zero or negative."); passr = false; }
            else if (w < 0) { Console.WriteLine("Width cannot be zero or negative."); passr = false; }
            if (h < 0) { Console.WriteLine("Height cannot be zero or negative."); passr = false; }
            return passr;
        }
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            if (pass(l, w, h))
            {
                Box box = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
        }
    }
}
