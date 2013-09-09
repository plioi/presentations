using System;
using System.Globalization;
using System.Reflection;

namespace Iteration04.Imports.ColumnParsers
{
    public class DateTimeColumnParser : IColumnParser
    {
        public bool CanHandle(PropertyInfo property)
        {
            return property.PropertyType == typeof(DateTime);
        }

        public object Parse(string value, DelimitedFile config)
        {
            return DateTime.ParseExact(value, config.TimeStampFormat, CultureInfo.InvariantCulture);
        }
    }
}