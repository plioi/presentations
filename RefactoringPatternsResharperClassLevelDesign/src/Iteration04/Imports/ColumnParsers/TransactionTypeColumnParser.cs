using System.Reflection;
using Iteration04.Model;

namespace Iteration04.Imports.ColumnParsers
{
    public class TransactionTypeColumnParser : IColumnParser
    {
        public bool CanHandle(PropertyInfo property)
        {
            return property.PropertyType == typeof(TransactionType);
        }

        public object Parse(string value, DelimitedFile config)
        {
            return TransactionType.GetTransactionType(value);
        }
    }
}