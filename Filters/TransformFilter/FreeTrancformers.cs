using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class FreeTrancformers : ITrancformer<EmptyParametrs>
    {
        Func<Size, Size> sizeTransformer;
        Func<Point, Size, Point> pointTransformer;

        Size oldSize;

        public FreeTrancformers(Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public Size ResultSize { get; private set; }

        public Point? PointMap(Point newPoint)
        {
            return pointTransformer(newPoint, oldSize);
        }

        public void Prepare(Size size, EmptyParametrs parametrs = null)
        {
            oldSize = size;
            ResultSize = sizeTransformer(size);
        }
    }
}
