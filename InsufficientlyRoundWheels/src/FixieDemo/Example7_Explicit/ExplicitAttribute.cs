using System;

namespace FixieDemo.Example7_Explicit
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ExplicitAttribute : Attribute { }
}