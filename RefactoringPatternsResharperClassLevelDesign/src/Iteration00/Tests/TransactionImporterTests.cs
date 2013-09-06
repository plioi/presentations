using System;
using System.Linq;
using Iteration00.Importers;
using Iteration00.Model;
using NUnit.Framework;
using Should;

namespace Iteration00.Tests
{
    [TestFixture]
    public class TransactionImporterTests
    {
        [Test]
        public void ShouldReadTransactionFile()
        {
            var importer = new TransactionImporter();
            var transactions = importer.Read("InputFiles\\Transactions.txt").ToArray();

            transactions.Length.ShouldEqual(3);

            transactions[0].Type.ShouldEqual(TransactionType.Deposit);
            transactions[0].Timestamp.ShouldEqual(new DateTime(2012, 2, 1, 13, 14, 25));
            transactions[0].Account.ShouldEqual("123456789");
            transactions[0].Description.ShouldEqual("Paycheck");

            transactions[1].Type.ShouldEqual(TransactionType.Deposit);
            transactions[1].Timestamp.ShouldEqual(new DateTime(2013, 3, 2, 9, 12, 32));
            transactions[1].Account.ShouldEqual("987654321");
            transactions[1].Description.ShouldEqual("Paycheck");

            transactions[2].Type.ShouldEqual(TransactionType.Withdrawal);
            transactions[2].Timestamp.ShouldEqual(new DateTime(2013, 3, 3, 8, 22, 33));
            transactions[2].Account.ShouldEqual("987654321");
            transactions[2].Description.ShouldEqual("Car Payment");
        }
    }
}