using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double red, double green, double blue)
        {
            r = g = b = 0;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Check(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException();
            else
                return value;
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        private double r;
        public double Red
        {
            get { return r; }
            set { r = Check(value); }
        }

        private double g;
        public double Green
        {
            get { return g; }
            set { g = Check(value); }
        }

        private double b;
        public double Blue
        {
            get { return b; }
            set { b = Check(value); }
        }
        public static Pixel operator *(Pixel pixel, double k)
        {
            return new Pixel(
                Trim(pixel.Red * k),
                Trim(pixel.Green * k),
                Trim(pixel.Blue * k));
        }

        public static Pixel operator *(double k, Pixel pixel)
        {
            return pixel * k;
        }
    }
}
