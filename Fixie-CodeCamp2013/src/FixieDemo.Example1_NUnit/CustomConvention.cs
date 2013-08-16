using System;
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
                .SetUpTearDown(Has<TestFixtureSetUpAttribute>(), Has<TestFixtureTearDownAttribute>());

            CaseExecution
                .SetUpTearDown(Has<SetUpAttribute>(), Has<TearDownAttribute>());
        }

        static MethodFilter Has<TAttribute>() where TAttribute : Attribute
        {
            return new MethodFilter().HasOrInherits<TAttribute>();
        }
    }
}
