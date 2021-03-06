using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter<TParameter> : ParametrizedFilter<TParameter>
        where TParameter : IParametrs, new()
    {
        string name;
        Func<Size, TParameter, Size> sizeTransform;
        Func<Point, Size, TParameter, Point?> pointTransform;

        public TransformFilter(string name, Func<Size, TParameter, Size> sizeTransform, Func<Point, Size, TParameter, Point?> pointTransform)
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, TParameter filter_parametrs)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize, filter_parametrs);
            var result = new Photo(newSize.Width, newSize.Height);

            for (int x = 0; x < newSize.Width; x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize, filter_parametrs);
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
