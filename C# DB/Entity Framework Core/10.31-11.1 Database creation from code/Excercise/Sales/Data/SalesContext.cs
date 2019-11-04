using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    public class SalesContext :DbContext
    {
        public SalesContext() { }
        public SalesContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SalesContext;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.Property(x => x.Name).IsUnicode(true);
                product.Property(x => x.Description).HasDefaultValue("No description");
            });
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(x => x.Name).IsUnicode(true);
                customer.Property(x => x.Email).IsUnicode(false);

            });
            modelBuilder.Entity<Store>(store =>
            {
                store.Property(x => x.Name).IsUnicode(true);
            });
            modelBuilder.Entity<Sale>(sale =>
            {
                sale.Property(d => d.Date).HasColumnType("DATETIME2").HasDefaultValueSql("GetDate()");
                sale.HasOne(x => x.Product).WithMany(x => x.Sales).HasForeignKey(x => x.ProductId).HasConstraintName("FK_Product");
                sale.HasOne(x => x.Store).WithMany(x => x.Sales).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Store");
                sale.HasOne(x => x.Customer).WithMany(x => x.Sales).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_Customer");
            });
        }
    }
}
