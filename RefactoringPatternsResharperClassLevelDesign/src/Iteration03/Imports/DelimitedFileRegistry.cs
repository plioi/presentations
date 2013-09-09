using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class DelimitedFileRegistry
    {
        private readonly IList<Action<ConfigurationStore>> _storeActions = new List<Action<ConfigurationStore>>();

        public DelimitedFileRegistry()
            : this(new PersonFile(), new TransactionFile())
        {
        }

        public DelimitedFileRegistry(params IDelimitedFile[] delimitedFiles)
        {
            delimitedFiles.ForEach(File);
        }

        public void File(IDelimitedFile file)
        {
            _storeActions.Add(cfg => cfg.AddFileConfiguration(file.BuildConfiguration()));
        }

        public ConfigurationStore Build()
        {
            var store = new ConfigurationStore();

            Apply(store);

            return store;
        }

        public void Apply(ConfigurationStore store)
        {
            _storeActions.ForEach(action => action(store));
        }
    }
}