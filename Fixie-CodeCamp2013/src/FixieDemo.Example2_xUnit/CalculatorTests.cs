using System;
using Should;

namespace FixieDemo.Example2_xUnit
{
    public class CalculatorTests : IUseFixture<FixtureData>, IDisposable
    {
        FixtureData fixtureData;
        readonly Calculator calculator;

        public CalculatorTests()
        {
            Console.Out.WhereAmI();

            calculator = new Calculator();
        }

        public void SetFixture(FixtureData data)
        {
            Console.Out.WhereAmI();

            fixtureData = data;
        }

        [Fact]
        public void ShouldAdd()
        {
            Console.Out.WhereAmI();

            calculator.Add(2, 3).ShouldEqual(5);
            fixtureData.Instance.ShouldEqual(1);
        }

        [Fact]
        public void ShouldSubtract()
        {
            Console.Out.WhereAmI();

            calculator.Subtract(5, 3).ShouldEqual(2);
            fixtureData.Instance.ShouldEqual(1);
        }

        public void Dispose()
        {
            Console.Out.WhereAmI();
        }
    }

    public class FixtureData
    {
        static int InstanceCounter;

        public int Instance { get; private set; }

        public FixtureData()
        {
            Instance = ++InstanceCounter;
        }
    }
}