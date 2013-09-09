using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class DelimitedFileRegistry
    {
        private readonly IList<Action<ConfigurationStore>> _storeActions = new List<Action<ConfigurationStore>>();

        public DelimitedFileRegistry()
        {
            File(new PersonFile());
            File(new TransactionFile());
        }

        public void File<TRow>(DelimitedFile<TRow> file) where TRow : new()
        {
            _storeActions.Add(cfg =>
            {
                var fileConfig = new DelimitedFileConfiguration(typeof(TRow));

                file.Apply(fileConfig);

                cfg.AddFileConfiguration(fileConfig);
            });
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