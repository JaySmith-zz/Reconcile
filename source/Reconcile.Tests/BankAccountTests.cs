using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reconcile;

namespace Reconcile.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void CanCalculateBalance()
        {
            var account = new Account
            {
                Name = "Test Account",
                AccountType = "Checking",
                StartingBalance = 1500.00m
            };

            // Add Debit Transactions
            // Ballance is now 
            account.Transactions.Add(new Transaction
            {
                Name = "Pay Bill 1",
                TransactionType = TransactionType.Debit,
                Amount = 500.00m
            });
            //account.AvailableBalance.ShouldEqual(1000.00m);

            Assert.AreEqual(account.AvailableBalance, 1000.00m);

            account.Transactions.Add(new Transaction
            {
                Name = "Pay Bill 2",
                TransactionType = TransactionType.Debit,
                Amount = 500.00m
            });
            //account.AvailableBalance.ShouldEqual(500.00m);

            account.Transactions.Add(new Transaction
            {
                Name = "Deposit 1",
                TransactionType = TransactionType.Credit,
                Amount = 1500.00m
            });
            //account.AvailableBalance.ShouldEqual(2000.00m);
            Assert.AreEqual(account.AvailableBalance, 2000.00m);
        }
    }
}
