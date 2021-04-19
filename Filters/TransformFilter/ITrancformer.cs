using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public interface ITrancformer<TParametrs>
        where TParametrs : IParametrs, new()
    {
        void Prepare(Size size, TParametrs parametrs);
        Size ResultSize { get; }
        Point? PointMap(Point newPoint);
    }
}
