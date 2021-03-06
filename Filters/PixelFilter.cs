using System;

namespace MyPhotoshop
{
    public class PixelFilter<TParameter> : ParametrizedFilter<TParameter>
		where TParameter : IParametrs, new()
	{
		string name;
		Func<Pixel, TParameter, Pixel> processor;

		public PixelFilter(string name, Func<Pixel, TParameter, Pixel> processor)
        {
			this.name = name;
			this.processor = processor;
        }

		public override Photo Process(Photo original, TParameter filter_parametrs)
		{
			var result = new Photo(original.width, original.height);

			for (int x = 0; x < result.width; x++)
				for (int y = 0; y < result.height; y++)
				{
					result[x, y] = processor(original[x, y], filter_parametrs);
				}
			return result;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
