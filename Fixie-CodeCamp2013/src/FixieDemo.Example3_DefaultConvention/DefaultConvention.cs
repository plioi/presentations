using Fixie;

namespace FixieDemo.Example3_DefaultConvention
{
    public class DefaultConvention : Fixie.Conventions.DefaultConvention
    {
        public DefaultConvention()
        {
            Classes
                .Where(type => type.IsInNamespace(GetType().Namespace));
        }
    }
}