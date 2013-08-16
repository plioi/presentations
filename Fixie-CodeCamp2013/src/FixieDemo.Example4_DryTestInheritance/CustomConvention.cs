﻿using System.Linq;
using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example4_DryTestInheritance
{
    public class CustomConvention : Convention
    {
        static readonly string[] LifecycleMethods = new[] { "FixtureSetUp", "FixtureTearDown", "SetUp", "TearDown" };

        public CustomConvention()
        {
            Classes
                .Where(type => type.IsInNamespace(GetType().Namespace))
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void())
                .Where(method => LifecycleMethods.All(x => x != method.Name))
                .ZeroParameters();

            ClassExecution
                .CreateInstancePerTestClass();

            InstanceExecution
                .SetUpTearDown(Method("FixtureSetUp"), Method("FixtureTearDown"));

            CaseExecution
                .SetUpTearDown(Method("SetUp"), Method("TearDown"));
        }

        static MethodFilter Method(string methodName)
        {
            return new MethodFilter().Where(x => x.HasSignature(typeof(void), methodName));
        }
    }
}
