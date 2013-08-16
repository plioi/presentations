using System;
using System.Reflection;
using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example1_NUnit
{
    public static class BehaviorBuilderExtensions
    {
        public static InstanceBehaviorBuilder SetUpTearDown<TSetUpAttribute, TTearDownAttribute>(this InstanceBehaviorBuilder builder)
            where TSetUpAttribute : Attribute
            where TTearDownAttribute : Attribute
        {
            return builder.SetUpTearDown(fixture => InvokeAll<TSetUpAttribute>(fixture.TestClass, fixture.Instance),
                                         fixture => InvokeAll<TTearDownAttribute>(fixture.TestClass, fixture.Instance));
        }

        public static CaseBehaviorBuilder SetUpTearDown<TSetUpAttribute, TTearDownAttribute>(this CaseBehaviorBuilder builder)
            where TSetUpAttribute : Attribute
            where TTearDownAttribute : Attribute
        {
            return builder.SetUpTearDown((@case, instance) => InvokeAll<TSetUpAttribute>(@case.Class, instance),
                                         (@case, instance) => InvokeAll<TTearDownAttribute>(@case.Class, instance));
        }

        static void InvokeAll<TAttribute>(Type type, object instance)
            where TAttribute : Attribute
        {
            foreach (var method in Has<TAttribute>().Filter(type))
            {
                try
                {
                    method.Invoke(instance, null);
                }
                catch (TargetInvocationException exception)
                {
                    throw new PreservedException(exception.InnerException);
                }
            }
        }

        static MethodFilter Has<TAttribute>() where TAttribute : Attribute
        {
            return new MethodFilter().HasOrInherits<TAttribute>();
        }
    }
}