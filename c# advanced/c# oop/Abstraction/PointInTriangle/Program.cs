using System;

namespace PointInTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rect = Console.ReadLine().Split();
            Rectangle rectangle = new Rectangle(new Point(int.Parse(rect[0]), int.Parse(rect[1])), new Point(int.Parse(rect[2]), int.Parse(rect[3])));
            int n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                string[] pt = Console.ReadLine().Split();
                Console.WriteLine(rectangle.Contains(new Point(int.Parse(pt[0]), int.Parse(pt[1]))));
                n--;
            }
        }
    }
}
