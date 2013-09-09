using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class ConfigurationStore
    {
        private readonly IDictionary<Type, DelimitedFileConfiguration> _fileConfigurations = new Dictionary<Type, DelimitedFileConfiguration>();

        public ConfigurationStore(DelimitedFileRegistry delimitedFileRegistry)
        {
            delimitedFileRegistry.Apply(this);
        }

        public DelimitedFileConfiguration GetFileConfiguration<TRow>()
        {
            return GetFileConfiguration(typeof(TRow));
        }

        public DelimitedFileConfiguration GetFileConfiguration(Type rowType)
        {
            return _fileConfigurations[rowType];
        }

        public void AddFileConfiguration(DelimitedFileConfiguration csvFileConfiguration)
        {
            _fileConfigurations[csvFileConfiguration.RowType] = csvFileConfiguration;
        }
    }
}