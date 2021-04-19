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
        ITrancformer<TParameter> tranceformer;

        public TransformFilter(string name, ITrancformer<TParameter> tranceformer)
        {
            this.name = name;
            this.tranceformer = tranceformer;
        }

        public override Photo Process(Photo original, TParameter filter_parametrs)
        {
            var oldSize = new Size(original.width, original.height);
            tranceformer.Prepare(oldSize, filter_parametrs);
            var newSize = tranceformer.ResultSize;
            var result = new Photo(newSize.Width, newSize.Height);

            for (int x = 0; x < newSize.Width; x++)
                for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = tranceformer.PointMap(point);
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
