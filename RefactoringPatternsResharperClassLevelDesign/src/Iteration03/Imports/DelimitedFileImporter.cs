using System;
using System.Collections.Generic;
using System.Globalization;
using Iteration03.Model;
using Microsoft.VisualBasic.FileIO;

namespace Iteration03.Imports
{
    public class DelimitedFileImporter
    {
        private readonly ConfigurationStore _configurationStore;

        public DelimitedFileImporter(ConfigurationStore configurationStore)
        {
            _configurationStore = configurationStore;
        }

        public IEnumerable<TRow> Import<TRow>() where TRow : new()
        {
            var config = _configurationStore.GetFileConfiguration<TRow>();

            var parser = new TextFieldParser(config.Path);
            parser.TextFieldType = FieldType.Delimited;
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(config.Delimiter.ToString());

            var items = new List<TRow>();

            while (!parser.EndOfData)
            {
                bool atHeaderLine = parser.LineNumber == 1 && config.HasHeaderLine;

                var fields = parser.ReadFields();

                if (atHeaderLine)
                    continue;

                items.Add(CreateItem<TRow>(config, fields));
            }

            parser.Close();

            return items.ToArray();
        }

        private TRow CreateItem<TRow>(IDelimitedFile config, string[] fields) where TRow : new()
        {
            var columns = config.Columns;

            var row = new TRow();

            for (int i = 0; i < columns.Count; i++)
            {
                var type = columns[i].PropertyType;
                object value = fields[i];

                if (type == typeof(decimal))
                    value = Decimal.Parse(fields[i]);
                else if (type == typeof(TransactionType))
                    value = TransactionType.GetTransactionType(fields[i]);
                else if (type == typeof(DateTime))
                    value = DateTime.ParseExact(fields[i], config.TimeStampFormat, CultureInfo.InvariantCulture);
                else if (type != typeof(string))
                    throw new Exception(GetType().Name + " does not support properties of type " + type);

                columns[i].SetProperty(row, value);
            }

            return row;
        }
    }
}