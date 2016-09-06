using System;

namespace Reconcile
{
    public class Transaction
    {
        public string TransactionType { get; set; }
        public bool Pending { get; set; }
        public DateTime DateRecorded { get; set; }
        public DateTime DatePosted { get; set; }
        public decimal Amount { get; set; }
        public string CheckNumber { get; set; }
        public string FitId { get; set; }
        public string Name{ get; set; }
        public string Memo { get; set; }
    }
}