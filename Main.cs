using System;
using System.Windows.Forms;
using System.Drawing;
using static System.Math;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParametrs>(
				"����������/����������",
				(pixel, parametrs) => pixel * parametrs.Coefficient
				));
			window.AddFilter(new PixelFilter<EmptyParametrs>(
				"������� ������",
				(pixel, parametrs) =>
					{
						var avr = (pixel.Blue + pixel.Green + pixel.Red) / 3;
						return new Pixel(avr, avr, avr);
					}
				));

			window.AddFilter(new TransformFilter<AngleParameter>(
				"��������� ��������", new Rotation()));

			window.AddFilter(new TransformFilter(
				"�������� �� �����������",
				size=>size,
				(point, size) => new Point(size.Width - point.X - 1, point.Y)));
			window.AddFilter(new TransformFilter(
				"������� �� ������� �������",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(size.Width - point.Y - 1, size.Height - point.X - 1)));
			window.AddFilter(new TransformFilter(
				"������� ������ ������� �������",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(size.Width - point.Y - 1, point.X)));

			Application.Run (window);
		}
	}
}
