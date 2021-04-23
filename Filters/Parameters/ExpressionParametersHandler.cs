using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MyPhotoshop
{
    public class ExpressionParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParametrs, new()
    {
        static ParameterInfo[] description;
        static Func<double[], TParameters> parser;

        static ExpressionParametersHandler()
        {
            description = typeof(TParameters)
                .GetProperties()
                .Select(_ => _.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(_ => _.Length > 0)
                .Select(_ => _[0])
                .Cast<ParameterInfo>()
                .ToArray();

            var properties = typeof(TParameters)
                .GetProperties()
                .Where(_ => _.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();

            var arg = Expression.Parameter(typeof(double[]), "values");

            var bindings = new List<MemberBinding>();
            for(var i = 0; i < properties.Length; i++)
            {
                var binding = Expression.Bind(
                    properties[i],
                    Expression.ArrayIndex(arg, Expression.Constant(i)));
                bindings.Add(binding);
            }

            var body = Expression.MemberInit(
                Expression.New(typeof(TParameters).GetConstructor(new Type[0])),
                bindings);

            var lambda = Expression.Lambda<Func<double[], TParameters>>(
                body,
                arg);

            parser = lambda.Compile();
        }

        public TParameters CreateParameters(double[] values)
        {
            return parser(values);
        }

        public ParameterInfo[] GetDiscription()
        {
            return description;
        }
    }
}
