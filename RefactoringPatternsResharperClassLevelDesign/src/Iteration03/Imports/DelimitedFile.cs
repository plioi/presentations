using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Iteration03.Imports
{
    public class DelimitedFile<TRow> where TRow : new()
    {
        private readonly IList<Action<DelimitedFileConfiguration>> _fileActions = new List<Action<DelimitedFileConfiguration>>();

        public void Path(string path)
        {
            _fileActions.Add(cfg => cfg.Path = path);
        }

        public void TimeStampFormat(string format)
        {
            _fileActions.Add(cfg => cfg.TimeStampFormat = format);
        }

        public void Delimiter(char delimiter)
        {
            _fileActions.Add(cfg => cfg.Delimiter = delimiter);
        }

        public void HasHeaderLine()
        {
            _fileActions.Add(cfg => cfg.HasHeaderLine = true);
        }

        public void Column(Expression<Func<TRow, object>> memberExpr)
        {
            _fileActions.Add(cfg => cfg.AddColumn(new DelimitedFileColumnConfiguration(memberExpr)));
        }

        public void Apply(DelimitedFileConfiguration configuration)
        {
            _fileActions.ForEach(fileAction => fileAction(configuration));
        }
    }
}