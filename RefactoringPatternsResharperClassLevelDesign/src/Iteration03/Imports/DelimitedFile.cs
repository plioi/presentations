using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Iteration03.Imports
{
    public abstract class DelimitedFile
    {
        private readonly List<DelimitedFileColumn> _columns = new List<DelimitedFileColumn>();

        protected DelimitedFile(Type rowType)
        {
            RowType = rowType;
        }

        public Type RowType { get; private set; }
        public string Path { get; protected set; }
        public char Delimiter { get; protected set; }
        public bool HasHeaderLine { get; protected set; }
        public string TimeStampFormat { get; protected set; }

        public IReadOnlyList<DelimitedFileColumn> Columns
        {
            get { return _columns; }
        }

        protected void Column(DelimitedFileColumn column)
        {
            _columns.Add(column);
        }
    }

    public class DelimitedFile<TRow> : DelimitedFile where TRow : new()
    {
        public DelimitedFile() : base(typeof(TRow)) { }
        
        public void Column(Expression<Func<TRow, object>> memberExpr)
        {
            Column(new DelimitedFileColumn(memberExpr));
        }
    }
}