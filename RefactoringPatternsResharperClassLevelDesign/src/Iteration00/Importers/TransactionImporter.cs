using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Iteration00.Model;

namespace Iteration00.Importers
{
    public class TransactionImporter
    {
        public Transaction[] Read(string path)
        {
            var lines = File.ReadAllLines(path);

            var transactions = new List<Transaction>();
            
            foreach (var line in lines)
            {
                var fields = line.Split(',');

                TransactionType type;

                if (fields[0] == "D")
                    type = TransactionType.Deposit;
                else if (fields[0] == "W")
                    type = TransactionType.Withdrawal;
                else
                    throw new NotSupportedException(string.Format("Transaction type {0} is not supported.", fields[0]));

                var transaction = new Transaction();

                transaction.Type = type;
                transaction.Timestamp = DateTime.ParseExact(fields[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                transaction.Account = fields[2];
                transaction.Amount = Decimal.Parse(fields[3]);
                transaction.Description = fields[4];

                transactions.Add(transaction);
            }

            return transactions.ToArray();
        }
    }
}