using OFXSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Reconcile
{
    public static class AccountImporter
    {
        public static void Import(Account account, string fileName)
        {
            var importAccount = LoadFromFile(fileName);

            // new transactions not on the ledger
            var newTransactions = importAccount.Transactions.Except(account.Transactions, new TransactionComparer()).ToList();

            // transactions on ledger not in 
            var pending = account.Transactions.Where(x => x.Pending == true).ToList();

            foreach (var newTranaction in newTransactions)
            {
                var match = FindMatchingTransaction(newTranaction, pending);

                if (match != null)
                {
                    match.FitId = newTranaction.FitId;
                    match.Pending = false;
                    match.Name = newTranaction.Name;
                } else
                {
                    account.Transactions.Add(newTranaction);
                }
            }
        }

        private static Transaction FindMatchingTransaction(Transaction itemToMatch, List<Transaction> transactions)
        {
            // see if there is a match on check number
            var foundTransaction = transactions.FirstOrDefault(x => x.CheckNumber == itemToMatch.CheckNumber);

            if (foundTransaction == null)
                foundTransaction = transactions.FirstOrDefault(x => x.TransactionType == itemToMatch.TransactionType && x.Amount == itemToMatch.Amount);

            return foundTransaction;
        }

        private static Account LoadFromFile(string fileName)
        {
            var account = new Account();

            var parser = new OFXDocumentParser();
            var ofx = parser.Import(new FileStream(fileName, FileMode.Open));

            account.BankId = ofx.Account.BankID;
            account.AccountId = ofx.Account.AccountID;
            account.AccountType = ofx.AccType.ToString();

            account.StartDate = ofx.StatementStart;
            account.EndDate = ofx.StatementEnd;

            account.LedgerBalance = ofx.Balance.LedgerBalance;
            account.LedgerBalanceDate = ofx.Balance.LedgerBalanceDate;

            account.AvailableBalance = ofx.Balance.AvaliableBalance;
            account.AvailableBalanceDate = ofx.Balance.AvaliableBalanceDate;

            foreach (var item in ofx.Transactions)
            {

                account.Transactions.Add(new Transaction
                {
                    Amount = item.Amount,
                    DatePosted = item.Date,
                    FitId = item.TransactionID,
                    CheckNumber = item.CheckNum,
                    Name = item.Name,
                    TransactionType = TransactionType.Credit//item.TransType.ToString()
                });
            }

            return account;
        }
    }

    
}
