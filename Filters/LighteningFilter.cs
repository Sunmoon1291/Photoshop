using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
		public LighteningFilter() : base(new LighteningParametrs()) { }
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}		

		public override Pixel EditPixel(Pixel original, IParametrs parametrs)
		{
			return original * (parametrs as LighteningParametrs).Coefficient;
		}
	}
}

