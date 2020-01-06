using System;

namespace P01._Square_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var rec = new Square();
            ResizeShape(rec);
        }
        public static void ResizeShape(Rectangle rec)
        {
            rec.Height *= 10;
        }
    }
}
