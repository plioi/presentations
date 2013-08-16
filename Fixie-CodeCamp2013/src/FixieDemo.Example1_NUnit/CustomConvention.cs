using Fixie.Conventions;

namespace FixieDemo.Example1_NUnit
{
    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes
                .HasOrInherits<TestFixtureAttribute>();

            Cases
                .HasOrInherits<TestAttribute>();

            ClassExecution
                    .CreateInstancePerTestClass();

            InstanceExecution
                .SetUpTearDown<TestFixtureSetUpAttribute, TestFixtureTearDownAttribute>();

            CaseExecution
                .SetUpTearDown<SetUpAttribute, TearDownAttribute>();
        }
    }
}
