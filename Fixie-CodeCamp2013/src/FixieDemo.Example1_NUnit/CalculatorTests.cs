using System;
using Should;

namespace FixieDemo.Example1_NUnit
{
    [TestFixture]
    public class CalculatorTests : IDisposable
    {
        Calculator calculator;

        public CalculatorTests()
        {
            Console.Out.WhereAmI();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.Out.WhereAmI();

            calculator = new Calculator();
        }

        [SetUp]
        public void SetUp()
        {
            Console.Out.WhereAmI();
        }

        [Test]
        public void ShouldAdd()
        {
            Console.Out.WhereAmI();

            calculator.Add(2, 3).ShouldEqual(5);
        }

        [Test]
        public void ShouldSubtract()
        {
            Console.Out.WhereAmI();

            calculator.Subtract(5, 3).ShouldEqual(2);
        }

        [TearDown]
        public void TearDown()
        {
            Console.Out.WhereAmI();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Console.Out.WhereAmI();
        }

        public void Dispose()
        {
            Console.Out.WhereAmI();
        }
    }
}
