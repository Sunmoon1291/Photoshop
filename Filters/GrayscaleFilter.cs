using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter<EmptyParametrs>
	{
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public override Pixel EditPixel(Pixel original, EmptyParametrs parametrs)
        {
			var avr = (original.Blue + original.Green + original.Red) / 3;
			return new Pixel(avr, avr, avr);
		}
	}
}

