using StructureMap;

namespace Iteration04.DependencyResolution
{
    public class DependencyRegistrar
    {
        static DependencyRegistrar()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.LookForRegistries();
            }));
        }

        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}
