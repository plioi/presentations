using System;
using DefaultArguments.Assert;

namespace DefaultArguments
{
    public class Example2__BasicDefaultArgumentTests
    {
        static class Greeter
        {
            public static string SayHello(string name = null)
            {
                return String.Format("Hello, {0}!", name ?? "you");
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