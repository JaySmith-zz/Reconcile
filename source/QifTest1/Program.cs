using Reconcile;
using System;
using System.Linq;

namespace QifTest1
{
    class Program
    {
        private static Magrathea.Data.FileDataRepository _dataStore;

        static void Main(string[] args)
        {
            var portfolioSaveFileName = @"C:\Temp\Reconcile\test2.rdb";
            var importFileName = @"C:\temp\Reconcile\import-B.ofx";
            var accountName = "Arvest Family Checking";

            _dataStore = new Magrathea.Data.FileDataRepository(portfolioSaveFileName);

            //CreateAccount(accountName, importFileName);
            UpdateAccount(portfolioSaveFileName, importFileName, accountName);
        }

        public static void UpdateAccount(string portfolioSaveFileName, string importFileName, string accountNameToUpdate)
        {
            _dataStore = new Magrathea.Data.FileDataRepository(portfolioSaveFileName);
            var portfolio = _dataStore.Read<Portfolio>();

            var account = portfolio.Accounts.FirstOrDefault(x => x.Name == accountNameToUpdate);
            account.Import(importFileName);

            _dataStore.Save(portfolio);
        }

        public static void CreateAccount(string accountName, string importFile)
        {
            var newAccount = new Account();
            newAccount.Name = accountName;
            newAccount.Import(importFile);

            var newTransaction = new Transaction();
            newTransaction.Name = "Church Tithe";
            newTransaction.DatePosted = DateTime.Now;
            newTransaction.Amount = decimal.Parse("-100.00");
            newTransaction.FitId = Guid.NewGuid().ToString();
            newTransaction.Pending = true;
            newAccount.Transactions.Add(newTransaction);

            var portfolio = new Portfolio();
            portfolio.Accounts.Add(newAccount);

            _dataStore.Save(portfolio);

        }

        public static Portfolio GetPortfolio(string portfolioFile)
        {
            var dataStore = new Magrathea.Data.FileDataRepository(portfolioFile);
            return dataStore.Read<Portfolio>();
        }
    }
}
