using System.Reflection;

namespace Iteration04.Imports.ColumnParsers
{
    public interface IColumnParser
    {
        bool CanHandle(PropertyInfo property);
        object Parse(string value, DelimitedFile config);
    }
}