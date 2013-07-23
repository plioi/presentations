namespace FixieDemo.Example6_Transactions
{
    /// <summary>
    /// Lame.
    /// </summary>
    public abstract class TransactionScopedTests
    {
        TransactionScope scope;

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }
    }
}
