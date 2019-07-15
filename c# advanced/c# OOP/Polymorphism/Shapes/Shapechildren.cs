using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle:Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }

        public override double CalculatePerimiter()
        {
            return radius * 2 * Math.PI;
        }
    }

    class Rectangle:Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimiter()
        {
            return 2 * (height + width);
        }
    }
}
