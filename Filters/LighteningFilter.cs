using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LighteningParametrs>
	{
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}		

		public override Pixel EditPixel(Pixel original, LighteningParametrs parametrs)
		{
			return original * parametrs.Coefficient;
		}
	}
}

