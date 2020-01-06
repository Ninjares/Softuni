using System;
using System.Collections.Generic;
using System.Text;

namespace PointInTriangle
{
    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Rectangle
    {
        public Point topleft;
        public Point bottomright;

        public Rectangle(Point tl, Point br)
        {
            topleft = tl;
            bottomright = br;
        }

        public bool Contains(Point point)
        {
            return point.x >= topleft.x && point.x <= bottomright.x &&
                 point.y >= topleft.y && point.y <= bottomright.y;
        }
    }
}
