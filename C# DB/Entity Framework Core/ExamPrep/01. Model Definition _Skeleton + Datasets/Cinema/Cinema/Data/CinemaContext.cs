namespace Cinema.Data
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)   { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(m =>
            {

            });
            modelBuilder.Entity<Projection>(p =>
            {
                p.HasOne(x => x.Hall).WithMany(h => h.Projections).HasForeignKey(x => x.HallId).HasConstraintName("FK_HallProjection");
                p.HasOne(x => x.Movie).WithMany(m => m.Projections).HasForeignKey(x => x.MovieId).HasConstraintName("FK_MovieProjection");
            });
            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);
                t.HasOne(x => x.Projection).WithMany(x => x.Tickets).HasForeignKey(x => x.ProjectionId);
                t.HasOne(x => x.Customer).WithMany(x => x.Tickets).HasForeignKey(x => x.CustomerId);
            });
            modelBuilder.Entity<Seat>(s =>
            {
                s.HasOne(x => x.Hall).WithMany(x => x.Seats).HasForeignKey(x => x.HallId);
            });
        }
    }
}
