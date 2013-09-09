using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class ConfigurationStore
    {
        private readonly IDictionary<Type, IDelimitedFile> _fileConfigurations = new Dictionary<Type, IDelimitedFile>();

        public ConfigurationStore(params IDelimitedFile[] delimitedFiles)
        {
            delimitedFiles.ForEach(Add);
        }

        public IDelimitedFile GetFileConfiguration<TRow>()
        {
            return _fileConfigurations[typeof(TRow)];
        }

        private void Add(IDelimitedFile file)
        {
            _fileConfigurations[file.RowType] = file;
        }
    }
}