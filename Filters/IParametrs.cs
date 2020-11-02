using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public interface IParametrs
    {
        ParameterInfo[] GetDescriptons();
        void SetValues(double[] values);
    }
}
