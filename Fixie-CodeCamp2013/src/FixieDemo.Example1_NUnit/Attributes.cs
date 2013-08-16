using System;

namespace FixieDemo.Example1_NUnit
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestFixtureAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class TestFixtureSetUpAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class SetUpAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class TearDownAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class TestFixtureTearDownAttribute : Attribute { }
}
