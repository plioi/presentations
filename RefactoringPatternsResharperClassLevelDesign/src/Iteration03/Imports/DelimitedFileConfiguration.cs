using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class DelimitedFileConfiguration
    {
        private readonly List<DelimitedFileColumnConfiguration> _columns = new List<DelimitedFileColumnConfiguration>();

        public DelimitedFileConfiguration(Type rowType)
        {
            RowType = rowType;
        }

        public Type RowType { get; set; }
        public string Path { get; set; }
        public char Delimiter { get; set; }
        public bool HasHeaderLine { get; set; }
        public string TimeStampFormat { get; set; }

        public IEnumerable<DelimitedFileColumnConfiguration> Columns
        {
            get { return _columns; }
        }

        public void AddColumn(DelimitedFileColumnConfiguration column)
        {
            _columns.Add(column);
        }
    }
}