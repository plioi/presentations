using System;
using System.Collections.Generic;

namespace Iteration03.Imports
{
    public class DelimitedFileRegistry
    {
        private readonly IList<Action<ConfigurationStore>> _storeActions = new List<Action<ConfigurationStore>>();

        public DelimitedFileRegistry(params IDelimitedFile[] delimitedFiles)
        {
            delimitedFiles.ForEach(File);
        }

        private void File(IDelimitedFile file)
        {
            _storeActions.Add(cfg => cfg.AddFileConfiguration(file.BuildConfiguration()));
        }

        public void Apply(ConfigurationStore store)
        {
            _storeActions.ForEach(action => action(store));
        }
    }
}