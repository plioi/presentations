using System;
using DefaultArguments.Assert;

namespace DefaultArguments
{
    public class Example1__BasicOverloadingTests
    {
        static class Greeter
        {
            public static string SayHello(string name)
            {
                return String.Format("Hello, {0}!", name ?? "you");
            }

            public static string SayHello()
            {
                return SayHello(null);
            }
        }

        public void Should_say_hello_you_when_no_name_is_given()
        {
            Greeter.SayHello().ShouldEqual("Hello, you!");
        }

        public void Should_greet_by_name_when_name_is_given()
        {
            Greeter.SayHello("Joe").ShouldEqual("Hello, Joe!");
        }
    }
}