using System;
using System.Collections.Generic;
using System.Text;
using P01._DrawingShape_Before.Contracts;

namespace P01._DrawingShape_Before
{
    public interface IShape
    {
        void Draw(IRenderer renderer, IDrawingContext drawingContext);
    }
}
