using System.Reflection;

namespace Iteration04.Imports.ColumnParsers
{
    public class StringColumnParser : IColumnParser
    {
        public bool CanHandle(PropertyInfo property)
        {
            return property.PropertyType == typeof(string);
        }

        public object Parse(string value, DelimitedFile config)
        {
            return value;
        }
    }
}