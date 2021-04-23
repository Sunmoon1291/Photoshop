using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class SimpleParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParametrs, new()
    {
        public TParameters CreateParameters(double[] values)
        {
            var parametrs = new TParameters();
            var proprties = parametrs
                .GetType()
                .GetProperties()
                .Where(_ => _.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            for (int i = 0; i < values.Length; i++)
                proprties[i].SetValue(parametrs, values[i], new object[0]);
            return parametrs;
        }

        public ParameterInfo[] GetDiscription()
        {
            return typeof(TParameters)
                .GetProperties()
                .Select(_ => _.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(_ => _.Length > 0)
                .Select(_ => _[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
    }
}
