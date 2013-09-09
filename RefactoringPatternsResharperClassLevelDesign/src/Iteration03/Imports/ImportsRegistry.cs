using StructureMap.Configuration.DSL;

namespace Iteration03.Imports
{
    public class ImportsRegistry : Registry
    {
        public ImportsRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<DelimitedFile>();
            });

            For<DelimitedFileImporter>().Singleton();
        }
    }
}