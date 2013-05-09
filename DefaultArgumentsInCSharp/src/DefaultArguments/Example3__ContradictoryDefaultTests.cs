using System;
using DefaultArguments.Assert;

namespace DefaultArguments
{
    public class Example3__ContradictoryDefaultTests
    {
        interface IGreeter
        {
            string SayHello(string name = "Jane");
        }

        class Greeter : IGreeter
        {
            public string SayHello(string name = null)
            {
                return String.Format("Hello, {0}!", name ?? "you");
            }
        }

        public void Should_get_different_default_value_depending_on_variable_declaration()
        {
            Greeter greeter = new Greeter();

            greeter.SayHello().ShouldEqual("Hello, you!");

            IGreeter igreeter = new Greeter();

            igreeter.SayHello().ShouldEqual("Hello, Jane!");

            // WHAT!?
        }

        public void Should_greet_by_name_when_name_is_given()
        {
            Greeter greeter = new Greeter();

            greeter.SayHello("Mike").ShouldEqual("Hello, Mike!");

            IGreeter igreeter = new Greeter();

            igreeter.SayHello("Mike").ShouldEqual("Hello, Mike!");
        }
    }
}