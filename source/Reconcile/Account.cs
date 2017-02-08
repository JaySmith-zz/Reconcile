using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reconcile
{
    public class Account
    {
        public Account()
        {
            Transactions = new ObservableCollection<Transaction>();
            Transactions.CollectionChanged += Transactions_CollectionChanged;
        }

        private void Transactions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var balance = StartingBalance;

            foreach (var transaction in Transactions)
            {
                if (transaction.TransactionType == TransactionType.Debit)
                    balance = balance - transaction.Amount;

                if (transaction.TransactionType == TransactionType.Credit)
                    balance = balance + transaction.Amount;
            }

            AvailableBalance = balance;
        }

        public Account(string accountName, decimal startingBalance)
        {
            Name = accountName;
            StartingBalance = startingBalance;
            Transactions = new ObservableCollection<Transaction>();
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

        public ObservableCollection<Transaction> Transactions { get; private set; }

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
