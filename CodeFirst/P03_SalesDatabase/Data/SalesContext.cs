using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }


        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options)
        :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.HasKey(e => e.ProductId);

        //        entity.Property(e => e.Name)
        //            .IsUnicode()
        //            .HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Customer>(entity =>
        //    {
        //        entity.HasKey(e => e.CustomerId);

        //        entity.Property(e => e.Name)
        //            .IsUnicode()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Email)
        //            .IsUnicode(false)
        //            .HasMaxLength(80);
                
        //    });

        //    modelBuilder.Entity<Store>(entity =>
        //    {
        //        entity.HasKey(e => e.StoreId);

        //        entity.Property(e => e.Name)
        //            .IsUnicode()
        //            .HasMaxLength(80);
        //    });

        //    modelBuilder.Entity<Sale>(entity =>
        //    {
        //        entity.HasKey(e => e.SaleId);

        //        entity.HasOne(e => e.Product)
        //            .WithMany(e => e.Sales)
        //            .HasForeignKey(e => e.ProductId);

        //        entity.HasOne(e => e.Customer)
        //            .WithMany(e => e.Sales)
        //            .HasForeignKey(e => e.CustomerId);

        //        entity.HasOne(e => e.Store)
        //            .WithMany(e => e.Sales)
        //            .HasForeignKey(e => e.StoreId);
        //    });
        //}
    }
}
