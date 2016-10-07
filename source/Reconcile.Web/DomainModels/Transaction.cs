namespace Reconcile.Web.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string TransactionType { get; set; }

        public bool? Pending { get; set; }

        public DateTime? DateRecorded { get; set; }

        public DateTime? DatePosted { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string CheckNumber { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(80)]
        public string Memo { get; set; }

        public int? BankAccountId { get; set; }

        public virtual BankAccount BankAccount { get; set; }
    }
}
