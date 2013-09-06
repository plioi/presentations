using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Iteration01.Importers
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
            return GetLines(path).Select(CreateItem).ToArray();
        }

        private IEnumerable<string[]> GetLines(string path)
        {
            var lines =
                _hasHeaderLine
                    ? File.ReadAllLines(path).Skip(1)
                    : File.ReadAllLines(path);
            
            return lines.Select(line => line.Split(_delimiter));
        }

        protected abstract T CreateItem(string[] fields);
    }
}