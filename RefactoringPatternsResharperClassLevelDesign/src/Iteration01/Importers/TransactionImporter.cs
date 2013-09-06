using System;
using System.Globalization;
using Iteration01.Model;

namespace Iteration01.Importers
{
    public class TransactionImporter : DelimitedFile<Transaction>
    {
        public TransactionImporter()
            :base(delimiter: ',', hasHeaderLine: false)
        {
        }

        protected override Transaction CreateItem(string[] fields)
        {
            TransactionType type;

            if (fields[0] == "D")
                type = TransactionType.Deposit;
            else if (fields[0] == "W")
                type = TransactionType.Withdrawal;
            else
                throw new NotSupportedException(string.Format("Transaction type {0} is not supported.", fields[0]));

            return new Transaction
            {
                Type = type,
                Timestamp = DateTime.ParseExact(fields[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Account = fields[2],
                Amount = Decimal.Parse(fields[3]),
                Description = fields[4]
            };
        }
    }
}