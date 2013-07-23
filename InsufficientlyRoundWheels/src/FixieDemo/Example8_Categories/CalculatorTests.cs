using System;
using Should;

namespace FixieDemo.Example8_Categories
{
    public class CalculatorTests
    {
        readonly Calculator calculator;

        public CalculatorTests()
        {
            Console.Out.WhereAmI();

            calculator = new Calculator();
        }

        [CategoryA]
        public void ShouldAdd()
        {
            Console.Out.WhereAmI();

            calculator.Add(2, 3).ShouldEqual(5);
        }

        [CategoryB]
        public void ShouldSubtract()
        {
            Console.Out.WhereAmI();

            calculator.Add(2, 3).ShouldEqual(5);
        }
    }
}