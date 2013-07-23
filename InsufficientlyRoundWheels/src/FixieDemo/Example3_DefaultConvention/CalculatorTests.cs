using System;
using Should;

namespace FixieDemo.Example3_DefaultConvention
{
    public class CalculatorTests : IDisposable
    {
        readonly Calculator calculator;

        public CalculatorTests()
        {
            Console.Out.WhereAmI();

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

        public void Dispose()
        {
            Console.Out.WhereAmI();
        }
    }
}