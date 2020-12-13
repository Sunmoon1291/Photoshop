using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameter> : IFilter
        where TParameter : IParametrs, new()
    {
        public ParameterInfo[] GetParameters()
        {
            return  new TParameter().GetDescriptons();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parametrs = new TParameter();
            parametrs.SetValues(values);
            return Process(original, parametrs);
        }

        public abstract Photo Process(Photo original, TParameter filter_parametrs);
    }
}
