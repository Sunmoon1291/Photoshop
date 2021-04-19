using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Math;

namespace MyPhotoshop
{
    public class Rotation : ITrancformer<AngleParameter>
    {
        public Size OriginalSize { get; private set; }
        public Size ResultSize { get; private set; }
        public double Angle { get; private set; }

        public Point? PointMap(Point Point)
        {
            var newSize = ResultSize;
            var oldSize = OriginalSize;
            Point = new Point(Point.X - newSize.Width / 2, Point.Y - newSize.Height / 2);
            var x = oldSize.Width / 2 + (int)(Point.X * Cos(Angle) + Point.Y * Sin(Angle));
            var y = oldSize.Height / 2 + (int)(Point.Y * Cos(Angle) - Point.X * Sin(Angle));
            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;
            return new Point(x, y);
        }

        public void Prepare(Size size, AngleParameter parametrs)
        {
            OriginalSize = size;
            Angle = PI * parametrs.Angle / 180;
            var newWidth = (int)(size.Width * Abs(Cos(Angle)) + size.Height * Abs(Sin(Angle)));
            var newHeight = (int)(size.Height * Abs(Cos(Angle)) + size.Width * Abs(Sin(Angle)));
            ResultSize = new Size(newWidth, newHeight);
        }
    }
}
