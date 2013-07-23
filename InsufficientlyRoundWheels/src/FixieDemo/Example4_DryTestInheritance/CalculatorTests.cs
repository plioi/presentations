using System;
using Should;

namespace FixieDemo.Example4_DryTestInheritance
{
    public class CalculatorTests : IDisposable
    {
        Calculator calculator;

        public CalculatorTests()
        {
            Console.Out.WhereAmI();
        }

        public void FixtureSetUp()
        {
            Console.Out.WhereAmI();

            calculator = new Calculator();
        }

        public void SetUp()
        {
            Console.Out.WhereAmI();
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

        public void TearDown()
        {
            Console.Out.WhereAmI();
        }

        public void FixtureTearDown()
        {
            Console.Out.WhereAmI();
        }

        public void Dispose()
        {
            Console.Out.WhereAmI();
        }
    }
}
