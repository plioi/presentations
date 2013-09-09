using System;

namespace Iteration02.Model
{
    public class Transaction
    {
        public TransactionType Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Account { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}