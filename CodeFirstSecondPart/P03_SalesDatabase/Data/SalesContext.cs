using System;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_Sales_Products");

                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.CustomerId)
                    .HasConstraintName("FK_Sales_Customers");

                entity.HasOne(e => e.Store)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.SaleId)
                    .HasForeignKey("FK_Sales_Stores");
            });
        }
    }
}
