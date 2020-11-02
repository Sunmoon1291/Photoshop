using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter
	{
		public GrayscaleFilter() : base(new EmptyParametrs()) { } 
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public override Pixel EditPixel(Pixel original, IParametrs parametrs)
        {
			var avr = (original.Blue + original.Green + original.Red) / 3;
			return new Pixel(avr, avr, avr);
		}
	}
}

