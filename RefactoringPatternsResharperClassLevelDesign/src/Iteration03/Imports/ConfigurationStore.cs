using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class ConfigurationStore
    {
        private readonly IDictionary<Type, DelimitedFileConfiguration> _fileConfigurations = new Dictionary<Type, DelimitedFileConfiguration>();

        public ConfigurationStore(params IDelimitedFile[] delimitedFiles)
        {
            delimitedFiles.ForEach(Add);
        }

        public DelimitedFileConfiguration GetFileConfiguration<TRow>()
        {
            return _fileConfigurations[typeof(TRow)];
        }

        private void Add(IDelimitedFile file)
        {
            var fileConfiguration = file.BuildConfiguration();

            _fileConfigurations[fileConfiguration.RowType] = fileConfiguration;
        }
    }
}