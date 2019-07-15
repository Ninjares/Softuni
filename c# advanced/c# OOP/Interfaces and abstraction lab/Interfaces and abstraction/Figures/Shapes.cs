using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public interface IDrawable
    {
        void Draw();
    }
    class Circle:IDrawable
    {
        private readonly int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            for(double y = this.radius; y>= -this.radius; --y)
            {
                for(double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if(value >= rIn * rIn && value < rOut * rOut)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
    class Rectangle:IDrawable
    {
        private readonly int width;
        private readonly int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++) Console.Write('*');
                }
                else
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (j == 0 || j == width - 1) Console.Write('*');
                        else Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
