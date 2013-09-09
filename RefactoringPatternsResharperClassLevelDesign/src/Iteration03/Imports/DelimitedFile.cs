using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Iteration03.Imports
{
    public interface IDelimitedFile
    {
        Type RowType { get; }
        string Path { get; }
        char Delimiter { get; }
        bool HasHeaderLine { get; }
        string TimeStampFormat { get; }
        IReadOnlyList<DelimitedFileColumn> Columns { get; }
    }

    public class DelimitedFile<TRow> : IDelimitedFile where TRow : new()
    {
        private readonly List<DelimitedFileColumn> _columns = new List<DelimitedFileColumn>();

        public Type RowType { get { return typeof(TRow); } }
        public string Path { get; protected set; }
        public char Delimiter { get; protected set; }
        public bool HasHeaderLine { get; protected set; }
        public string TimeStampFormat { get; protected set; }

        public void Column(Expression<Func<TRow, object>> memberExpr)
        {
            _columns.Add(new DelimitedFileColumn(memberExpr));
        }

        public IReadOnlyList<DelimitedFileColumn> Columns
        {
            get { return _columns; }
        }
    }
}