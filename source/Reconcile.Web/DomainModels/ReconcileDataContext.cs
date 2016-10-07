namespace Reconcile.Web.DomainModels
{
    using System.Data.Entity;

    public partial class ReconcileDataContext : DbContext
    {
        public ReconcileDataContext()
            : base("name=ReconcileDataContext")
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.YieldPercent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.BeginingBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.MinimumBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.TransactionType)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.CheckNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Memo)
                .IsUnicode(false);
        }
    }
}
