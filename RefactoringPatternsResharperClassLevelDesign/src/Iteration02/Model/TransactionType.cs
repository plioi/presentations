using Headspring;

namespace Iteration02.Model
{
    public class TransactionType : Enumeration<TransactionType>
    {
        public static readonly TransactionType Deposit = new TransactionType(0, "Deposit");
        public static readonly TransactionType Withdrawal = new TransactionType(1, "Withdrawal");

        private TransactionType(int value, string displayName)
            : base(value, displayName)
        {
        }

        public string Code { get; private set; }
    }
}