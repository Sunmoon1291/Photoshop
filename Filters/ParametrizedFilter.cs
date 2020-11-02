using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParametrs parametrs;

        public ParametrizedFilter(IParametrs filter_parametrs)
        {
            parametrs = filter_parametrs;
        }

        public ParameterInfo[] GetParameters()
        {
            return parametrs.GetDescriptons();
        }

        public Photo Process(Photo original, double[] values)
        {
            parametrs.SetValues(values);
            return Process(original, parametrs);
        }

        public abstract Photo Process(Photo original, IParametrs filter_parametrs);
    }
}
