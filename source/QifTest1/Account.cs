using System;
using System.Collections.Generic;

namespace Reconcile
{
    public class Account
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        public Account(string accountName, decimal startingBalance)
        {
            Name = accountName;
            StartingBalance = startingBalance;
            Transactions = new List<Transaction>();
        }

        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal LedgerBalance { get; set; }
        public DateTime LedgerBalanceDate { get; set; }
        public decimal AvailableBalance { get; set; }
        public DateTime AvailableBalanceDate { get; set; }

        public List<Transaction> Transactions { get; set; }

        public decimal LastBalanceDate { get; set; }
        public DateTime LastBalanceAmount { get; set; }

        public decimal StartingBalance { get; set; }
        public string Name { get; set; }

        public void Import(string importFileName)
        {
            AccountImporter.Import(this, importFileName);

        }
    }

}
