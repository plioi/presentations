using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Iteration03.Imports
{
    public interface IDelimitedFile
    {
        DelimitedFileConfiguration BuildConfiguration();
    }

    public class DelimitedFile<TRow> : IDelimitedFile where TRow : new()
    {
        private readonly IList<DelimitedFileColumn> _columns = new List<DelimitedFileColumn>();

        private string _path;
        private string _timeStampFormat;
        private char _delimiter;
        private bool _hasHeaderLine;

        public void Path(string path)
        {
            _path = path;
        }

        public void TimeStampFormat(string format)
        {
            _timeStampFormat = format;
        }

        public void Delimiter(char delimiter)
        {
            _delimiter = delimiter;
        }

        public void HasHeaderLine()
        {
            _hasHeaderLine = true;
        }

        public void Column(Expression<Func<TRow, object>> memberExpr)
        {
            _columns.Add(new DelimitedFileColumn(memberExpr));
        }

        public DelimitedFileConfiguration BuildConfiguration()
        {
            var fileConfig = new DelimitedFileConfiguration(typeof(TRow))
            {
                Path = _path,
                TimeStampFormat = _timeStampFormat,
                Delimiter = _delimiter,
                HasHeaderLine = _hasHeaderLine
            };

            _columns.ForEach(fileConfig.AddColumn);

            return fileConfig;
        }
    }
}