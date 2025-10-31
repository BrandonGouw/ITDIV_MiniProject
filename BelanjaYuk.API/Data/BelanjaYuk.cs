using Beliyuk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Beliyuk.API.Data
{
    public class BelanjaYuk : DbContext
    {
        public BelanjaYuk(DbContextOptions<BelanjaYuk> options) : base(options)
        {
        }

        public DbSet<MsUser> MsUser { get; set; }
        public DbSet<MsUserPassword> MsUserPasswords { get; set; }
        public DbSet<MsUserSeller> MsUserSellers { get; set; }
        public DbSet<MsProduct> MsProducts { get; set; }

        public DbSet<LtCategory> LtCategories { get; set; }
        public DbSet<LtGender> LtGenders { get; set; }
        public DbSet<LtPayment> LtPayments { get; set; }

        public DbSet<TrProductImages> TrProductImages { get; set; }
        public DbSet<TrBuyerCart> TrBuyerCarts { get; set; }
        public DbSet<TrBuyerTransaction> TrBuyerTransactions { get; set; }
        public DbSet<TrBuyerTransactionDetail> TrBuyerTransactionDetails { get; set; }
        public DbSet<TrHomeAddress> TrHomeAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<TrBuyerCart>()
                 .HasOne(bc => bc.Product)
                 .WithMany()
                 .HasForeignKey(bc => bc.IdProduct)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrBuyerCart>()
                 .HasOne(bc => bc.User)
                 .WithMany()
                 .HasForeignKey(bc => bc.IdUser)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrBuyerTransactionDetail>()
                 .HasOne(td => td.Product)
                 .WithMany()
                 .HasForeignKey(td => td.IdProduct)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TrBuyerTransactionDetail>()
                 .HasOne(td => td.BuyerTransaction)
                 .WithMany()
                 .HasForeignKey(td => td.IdBuyerTransaction)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MsUser>().ToTable("MsUser");
            modelBuilder.Entity<MsUserPassword>().ToTable("MsUserPassword");
            modelBuilder.Entity<MsUserSeller>().ToTable("MsUserSeller");
            modelBuilder.Entity<MsProduct>().ToTable("MsProduct");
            modelBuilder.Entity<LtCategory>().ToTable("LtCategory");
            modelBuilder.Entity<LtGender>().ToTable("LtGender");
            modelBuilder.Entity<LtPayment>().ToTable("LtPayment");
            modelBuilder.Entity<TrProductImages>().ToTable("TrProductImages");
            modelBuilder.Entity<TrBuyerCart>().ToTable("TrBuyerCart");
            modelBuilder.Entity<TrBuyerTransaction>().ToTable("TrBuyerTransaction");
            modelBuilder.Entity<TrBuyerTransactionDetail>().ToTable("TrBuyerTransactionDetail");
            modelBuilder.Entity<TrHomeAddress>().ToTable("TrHomeAddress");
        }
    }
}