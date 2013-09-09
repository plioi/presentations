using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Iteration02.Importers
{
    public abstract class DelimitedFile<T>
    {
        private readonly char _delimiter;
        private readonly bool _hasHeaderLine;

        protected DelimitedFile(char delimiter, bool hasHeaderLine)
        {
            _delimiter = delimiter;
            _hasHeaderLine = hasHeaderLine;
        }

        public T[] Read(string path)
        {
            var parser = new TextFieldParser(path);
            parser.TextFieldType = FieldType.Delimited;
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(_delimiter.ToString());

            var items = new List<T>();

            while (!parser.EndOfData)
            {
                bool atHeaderLine = parser.LineNumber == 1 && _hasHeaderLine;

                var fields = parser.ReadFields();

                if (atHeaderLine)
                    continue;

                items.Add(CreateItem(fields));
            }

            parser.Close();

            return items.ToArray();
        }

        protected abstract T CreateItem(string[] fields);
    }
}