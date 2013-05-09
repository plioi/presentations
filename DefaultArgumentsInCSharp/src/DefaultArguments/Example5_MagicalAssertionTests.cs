using Should;
//using DefaultArguments.Assert;

namespace DefaultArguments
{
    public class Example5_MagicalAssertionTests
    {
        public void Should_fail_int_assertion()
        {
            int x = 5*3;

            x.ShouldEqual(16);

            // Expected: 16
            // Actual:   15
        }

        public void Should_fail_string_assertion()
        {
            SayHello("Kel Varnsen").ShouldEqual("Hello, Kel Varnsen!");

            // Expected: Hello, Kel Varnsen!
            // Actual:   Hello, Dr. Van Nostrand!
        }

        private string SayHello(string name)
        {
            return "Hello, Dr. Van Nostrand!";
        }
    }
}