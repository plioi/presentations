using System;
using System.Reflection;

namespace Iteration04.Imports.ColumnParsers
{
    public class DecimalColumnParser : IColumnParser
    {
        public bool CanHandle(PropertyInfo property)
        {
            return property.PropertyType == typeof(Decimal);
        }

        public object Parse(string value, DelimitedFile config)
        {
            return Decimal.Parse(value);
        }
    }
}