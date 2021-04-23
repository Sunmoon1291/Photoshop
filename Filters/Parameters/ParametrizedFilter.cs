using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameter> : IFilter
        where TParameter : IParametrs, new()
    {
        IParametersHandler<TParameter> handler = new ExpressionParametersHandler<TParameter>();

        public ParameterInfo[] GetParameters()
        {
            return handler.GetDiscription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parametrs = handler.CreateParameters(values);
            return Process(original, parametrs);
        }

        public abstract Photo Process(Photo original, TParameter filter_parametrs);
    }
}
