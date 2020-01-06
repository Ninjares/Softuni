using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);
            var shapes = new List<IDrawable>() { circle, rect, new Rectangle(10, 10) };
            var shapes2 = new List<object>() { circle, rect, new Rectangle(10, 10), new string[] { "1", "2" },  };
            DrawAllFigures2(shapes2);
        }
        static void DrawAllFigures(IEnumerable<IDrawable> drawables)
        {
            foreach (IDrawable shape in drawables) shape.Draw();
        }
        static void DrawAllFigures2(IEnumerable<object> drawables)
        {
            foreach (var shape in drawables)
            {
                if (shape is IDrawable sp)
                {
                    sp.Draw();
                }
            }
        }
        static void DrawAllFigures3(IEnumerable<dynamic> drawables)
        {
            foreach (var shape in drawables)
            {
                shape.Draw(); 
            }
        }
    }
}
