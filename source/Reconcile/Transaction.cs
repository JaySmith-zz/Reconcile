using System;

namespace Reconcile
{
    public enum TransactionType
    {
        Debit,
        Credit
    }

public class Transaction
    {
        public TransactionType TransactionType { get; set; }
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