using Headspring;

namespace Iteration02.Model
{
    public class TransactionType : Enumeration<TransactionType>
    {
        public static readonly TransactionType Deposit = new TransactionType(0, "Deposit", "D");
        public static readonly TransactionType Withdrawal = new TransactionType(1, "Withdrawal", "W");

        private TransactionType(int value, string displayName, string code)
            : base(value, displayName)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}