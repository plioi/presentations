using System;
using System.Collections.Generic;
using System.Linq;
using Iteration04.Imports.ColumnParsers;
using Microsoft.VisualBasic.FileIO;

namespace Iteration04.Imports
{
    public class DelimitedFileImporter
    {
        private readonly IDictionary<Type, DelimitedFile> _filesByType;
        private readonly IColumnParser[] _columnParsers;

        public DelimitedFileImporter(DelimitedFile[] delimitedFiles, IColumnParser[] columnParsers)
        {
            _columnParsers = columnParsers;
            _filesByType = delimitedFiles.ToDictionary(file => file.RowType);
        }

        public IEnumerable<TRow> Import<TRow>() where TRow : new()
        {
            var file = _filesByType[typeof(TRow)];

            var parser = new TextFieldParser(file.Path);
            parser.TextFieldType = FieldType.Delimited;
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(file.Delimiter.ToString());

            var items = new List<TRow>();

            while (!parser.EndOfData)
            {
                bool atHeaderLine = parser.LineNumber == 1 && file.HasHeaderLine;

                var fields = parser.ReadFields();

                if (atHeaderLine)
                    continue;

                items.Add(CreateItem<TRow>(file, fields));
            }

            parser.Close();

            return items.ToArray();
        }

        private TRow CreateItem<TRow>(DelimitedFile config, string[] fields) where TRow : new()
        {
            var columns = config.Columns;

            var row = new TRow();

            for (int i = 0; i < columns.Count; i++)
            {
                var value = Parse<TRow>(fields[i], config, columns[i]);

                columns[i].SetProperty(row, value);
            }

            return row;
        }

        private object Parse<TRow>(string rawValue, DelimitedFile config, DelimitedFileColumn column)
        {
            foreach (var columnParser in _columnParsers)
                if (columnParser.CanHandle(column.Property))
                    return columnParser.Parse(rawValue, config);

            throw new Exception(string.Format("{0} does not support property {1}.{2}.", GetType().Name, typeof(TRow).Name, column.Property.Name));
        }
    }
}