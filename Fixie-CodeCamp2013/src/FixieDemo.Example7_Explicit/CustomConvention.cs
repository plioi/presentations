using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example7_Explicit
{
    public class CustomConvention : Convention
    {
        public CustomConvention(RunContext runContext)
        {
            Classes
                .Where(type => type.IsInNamespace(GetType().Namespace))
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void())
                .ZeroParameters()
                .Where(method =>
                {
                    var isMarkedExplicit = method.Has<ExplicitAttribute>();

                    return !isMarkedExplicit || runContext.TargetMember == method;
                });

            ClassExecution
                .CreateInstancePerTestClass();
        }
    }
}