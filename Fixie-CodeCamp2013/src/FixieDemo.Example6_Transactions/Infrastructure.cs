using System;

namespace FixieDemo.Example6_Transactions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SetUpAttribute : Attribute { }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class TearDownAttribute : Attribute { }

    public class TransactionScope : IDisposable
    {
        public TransactionScope()
        {
            Console.WriteLine("Starting transaction.");
        }

        public void Dispose()
        {
            Console.WriteLine("Rolling back transaction.");
        }
    }
}
