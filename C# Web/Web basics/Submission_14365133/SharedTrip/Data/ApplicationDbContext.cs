namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserTrip>(ut =>
            {
                ut.HasKey(x => new { x.TripId, x.UserId });
                ut.HasOne(x => x.User).WithMany(x => x.UserTrips).HasForeignKey(x => x.UserId);
                ut.HasOne(x => x.Trip).WithMany(x => x.UserTrips).HasForeignKey(x => x.TripId);
            });
        }
    }
}
