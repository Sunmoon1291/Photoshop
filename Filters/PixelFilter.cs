using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class PixelFilter<TParameter> : ParametrizedFilter<TParameter>
		where TParameter : IParametrs, new()
	{
		public abstract Pixel EditPixel(Pixel original, TParameter parametrs);

		public override Photo Process(Photo original, TParameter filter_parametrs)
		{
			var result = new Photo(original.width, original.height);

			for (int x = 0; x < result.width; x++)
				for (int y = 0; y < result.height; y++)
				{
					result[x, y] = EditPixel(original[x, y], filter_parametrs);
				}
			return result;
		}
	}
}
