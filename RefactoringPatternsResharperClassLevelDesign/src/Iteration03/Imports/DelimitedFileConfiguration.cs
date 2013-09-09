using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class DelimitedFileConfiguration
    {
        private readonly List<DelimitedFileColumn> _columns = new List<DelimitedFileColumn>();

        public DelimitedFileConfiguration(Type rowType)
        {
            RowType = rowType;
        }

        public Type RowType { get; set; }
        public string Path { get; set; }
        public char Delimiter { get; set; }
        public bool HasHeaderLine { get; set; }
        public string TimeStampFormat { get; set; }

        public IEnumerable<DelimitedFileColumn> Columns
        {
            get { return _columns; }
        }

        public void AddColumn(DelimitedFileColumn column)
        {
            _columns.Add(column);
        }
    }
}