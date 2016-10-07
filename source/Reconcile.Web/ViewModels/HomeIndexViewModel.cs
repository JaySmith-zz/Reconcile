using System;

namespace Reconcile.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public decimal AccountBalance { get; set; }

        public string AccountType { get; set; }

        public DateTime  LastUpdatedDate { get; set; }
    }
}