using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example7_Explicit
{
    public class CustomConvention : Convention
    {
        public CustomConvention(RunContext runContext)
        {
            Classes
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void())
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