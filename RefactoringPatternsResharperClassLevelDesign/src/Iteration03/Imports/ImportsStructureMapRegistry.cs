using StructureMap.Configuration.DSL;

namespace Iteration03.Imports
{
    public class ImportsStructureMapRegistry : Registry
    {
        public ImportsStructureMapRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AddAllTypesOf<IDelimitedFile>();
            });

            For<DelimitedFileImporter>().Singleton();
        }
    }
}