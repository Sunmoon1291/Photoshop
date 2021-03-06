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
				"Осветление/затемнение",
				(pixel, parametrs) => pixel * parametrs.Coefficient
				));
			window.AddFilter(new PixelFilter<EmptyParametrs>(
				"Оттенки серого",
				(pixel, parametrs) =>
					{
						var avr = (pixel.Blue + pixel.Green + pixel.Red) / 3;
						return new Pixel(avr, avr, avr);
					}
				));

			Func<Size, AngleParameter, Size> sizeTransform = (oldSize, parameter) =>
			{
				var angle = PI * parameter.Angle / 180;
				var newWidth = (int)(oldSize.Width * Abs(Cos(angle)) + oldSize.Height * Abs(Sin(angle)));
				var newHeight = (int)(oldSize.Height * Abs(Cos(angle)) + oldSize.Width * Abs(Sin(angle)));
				return new Size(newWidth, newHeight);
			};

			Func<Point, Size, AngleParameter, Point?> pointTransform = (oldPoint, oldSize, parameter) =>
			{
				var newSize = sizeTransform(oldSize, parameter);
				var angle = PI * parameter.Angle / 180;
				oldPoint = new Point(oldPoint.X - newSize.Width / 2, oldPoint.Y - newSize.Height / 2);
				var x = oldSize.Width / 2 + (int)(oldPoint.X * Cos(angle) + oldPoint.Y * Sin(angle));
				var y = oldSize.Height / 2 + (int)(oldPoint.Y * Cos(angle) - oldPoint.X * Sin(angle));
				if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
					return null;
				return new Point(x, y);
			};

			window.AddFilter(new TransformFilter<AngleParameter>(
				"Свободное вращение", sizeTransform, pointTransform));

			/*window.AddFilter(new TransformFilter(
				"Отразить по горизонтали",
				size=>size,
				(point, size) => new Point(size.Width - point.X - 1, point.Y)));
			window.AddFilter(new TransformFilter(
				"Поворот по часовой стрелке",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(size.Width - point.Y - 1, size.Height - point.X - 1)));
			window.AddFilter(new TransformFilter(
				"Поворот против часовой стрелки",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(size.Width - point.Y - 1, point.X)));*/
			Application.Run (window);
		}
	}
}
