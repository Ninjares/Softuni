using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Data
{
    using Microsoft.EntityFrameworkCore;
    using Sales.Data.Models;
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
            });
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(x => x.Name).IsUnicode(true);
                //customer.Property(x => x.Email).IsUnicode(false);

            });
            modelBuilder.Entity<Store>(store =>
            {
                store.Property(x => x.Name).IsUnicode(true);
            });
            modelBuilder.Entity<Sale>(sale =>
            {
                sale.HasOne(x => x.Product).WithMany(x => x.Sales).HasForeignKey(x => x.ProductId).HasConstraintName("FK_Product");
                sale.HasOne(x => x.Store).WithMany(x => x.Sales).HasForeignKey(x => x.StoreId).HasConstraintName("FK_Store");
                sale.HasOne(x => x.Customer).WithMany(x => x.Sales).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_Customer");
            });
        }
    }
}
