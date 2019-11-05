namespace CarSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using CarSystem.Data.Models;
    class CarDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CarSystem;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>(mk =>
            {
                mk.HasKey(x => x.Id);
                mk.HasIndex(x => x.Name).IsUnique();
            });
            modelBuilder.Entity<Model>(c =>
            {
                c.HasOne(x => x.Make).WithMany(m => m.Models).HasForeignKey(x => x.MakeId).HasConstraintName("FK_ModelMake");
            });
            modelBuilder.Entity<Car>(c =>
            {
                c.HasOne(x => x.Model).WithMany(m => m.Cars).HasForeignKey(x => x.ModelId).HasConstraintName("FK_CarModel");
                c.HasOne(x => x.Sale).WithOne(s => s.Car).HasForeignKey<Sale>(x => x.CarId).HasConstraintName("FK_CarSale"); //One-to-One
            });
            modelBuilder.Entity<Sale>(s =>
            {
                s.HasOne(x => x.Address).WithMany(c => c.Sales).HasForeignKey(x => x.AddressId).HasConstraintName("FK_SaleAddress");
                s.HasOne(x => x.Customer).WithMany(c => c.Sales).HasForeignKey(x => x.CustomerId).HasConstraintName("FK_SaleCustomer");
            });
        }
    }
}
