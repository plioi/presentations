using Iteration03.Model;

namespace Iteration03.Imports
{
    public class TransactionFile : DelimitedFile<Transaction>
    {
        public TransactionFile()
        {
            Path = "InputFiles\\Transactions.txt";
            TimeStampFormat = "yyyy-MM-dd HH:mm:ss";
            Delimiter = ',';

            Column(x => x.Type);
            Column(x => x.Timestamp);
            Column(x => x.Account);
            Column(x => x.Amount);
            Column(x => x.Description);
        }
    }
}