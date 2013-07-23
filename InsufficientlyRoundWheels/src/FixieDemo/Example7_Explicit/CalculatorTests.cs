using System;
using Should;

namespace FixieDemo.Example7_Explicit
{
    public class CalculatorTests
    {
        readonly Calculator calculator;

        public CalculatorTests()
        {
            calculator = new Calculator();
        }

        public void ShouldAdd()
        {
            Console.Out.WhereAmI();

            calculator.Add(2, 3).ShouldEqual(5);
        }

        public void ShouldSubtract()
        {
            Console.Out.WhereAmI();

            calculator.Subtract(5, 3).ShouldEqual(2);
        }

        [Explicit]
        public void ExplicitTest()
        {
            Console.Out.WhereAmI();
        }
    }
}