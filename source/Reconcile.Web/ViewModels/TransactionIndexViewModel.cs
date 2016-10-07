using System.Collections.Generic;
using Reconcile.Web.DomainModels;

namespace Reconcile.Web.ViewModels
{
    internal class TransactionIndexViewModel
    {
        public double Balance { get; set; }
        public double AvailableCash { get; set; }
        public double TotalFees { get; set; }
        public IEnumerable<BankAccount> Accounts { get; set; }
    }
}