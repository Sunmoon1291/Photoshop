﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class AngleParameter : IParametrs
    {
        [ParameterInfo(Name = "Угол", MaxValue = 360, MinValue = 0, Increment = 5, DefaultValue = 0)]
        public double Angle { get; set; }
    }
}
