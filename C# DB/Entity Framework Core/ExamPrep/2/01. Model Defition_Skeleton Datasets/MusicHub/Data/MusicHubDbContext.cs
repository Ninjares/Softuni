namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Song>(s =>
            {
                s.HasOne(x => x.Writer).WithMany(w => w.Songs).HasForeignKey(x => x.WriterId);
                s.HasOne(x => x.Album).WithMany(a => a.Songs).HasForeignKey(x => x.AlbumId);
            });
            builder.Entity<SongPerformer>(sp =>
            {
                sp.HasKey(x => new { x.PerformerId, x.SongId });
                sp.HasOne(x => x.Performer).WithMany(p => p.PerformerSongs).HasForeignKey(x => x.PerformerId);
                sp.HasOne(x => x.Song).WithMany(s => s.SongPerformers).HasForeignKey(x => x.SongId);
            });
            builder.Entity<Album>(a =>
            {
                a.HasOne(x => x.Producer).WithMany(p => p.Albums).HasForeignKey(x => x.ProducerId);
            });
        }
    }
}
