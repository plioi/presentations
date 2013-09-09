using System;
using System.Globalization;
using Iteration02.Model;

namespace Iteration02.Importers
{
    public class TransactionImporter : DelimitedFile<Transaction>
    {
        public TransactionImporter()
            :base(delimiter: ',', hasHeaderLine: false)
        {
        }

        protected override Transaction CreateItem(string[] fields)
        {
            return new Transaction
            {
                Type = TransactionType.GetTransactionType(fields[0]),
                Timestamp = DateTime.ParseExact(fields[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Account = fields[2],
                Amount = Decimal.Parse(fields[3]),
                Description = fields[4]
            };
        }
    }
}