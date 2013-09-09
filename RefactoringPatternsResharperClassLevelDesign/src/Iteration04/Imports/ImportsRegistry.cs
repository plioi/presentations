using Iteration04.Imports.ColumnParsers;
using StructureMap.Configuration.DSL;

namespace Iteration04.Imports
{
    public class ImportsRegistry : Registry
    {
        public ImportsRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<DelimitedFile>();
                scan.AddAllTypesOf<IColumnParser>();
            });

            For<DelimitedFileImporter>().Singleton();
        }
    }
}