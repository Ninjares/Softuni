namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }
        public FootballBettingContext(DbContextOptions options) : base(options) { }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FootballBetting;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(t =>
            {
                t.Property(x => x.Name).HasMaxLength(50).IsUnicode(true);
                t.Property(x => x.LogoUrl).HasMaxLength(300).IsUnicode(false);
                t.Property(x => x.Initials).IsFixedLength(true).HasMaxLength(3).IsUnicode(false);
                t.HasOne(x => x.Town).WithMany(x => x.Teams).HasForeignKey(x => x.TownId).HasConstraintName("FK_TeamTown");
                t.HasOne(x => x.PrimaryKitColor).WithMany(x => x.PrimaryKitTeams).HasForeignKey(x => x.PrimaryKitColorId).HasConstraintName("FK_PrimaryKitColor");
                t.HasOne(x => x.SecondaryKitColor).WithMany(x => x.SecondaryKitTeams).HasForeignKey(x => x.SecondaryKitColorId).HasConstraintName("FK_SecondaryKitColor");
                //PrimaryKitNotEqualToSecondaryKit?
            });
            modelBuilder.Entity<Town>(t =>
            {
                t.Property(x => x.Name).HasMaxLength(50).IsRequired(true).IsUnicode(true);
                t.HasOne(x => x.Country).WithMany(x => x.Towns).HasForeignKey(x => x.CountryId).HasConstraintName("FK_CountryTown");
            });
            modelBuilder.Entity<Player>(p =>
            {
                p.Property(x => x.Name).IsRequired(true).IsUnicode(true).HasMaxLength(100);
                p.Property(x => x.SquadNumber);
                p.HasOne(x => x.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamId).HasConstraintName("FK_PlayerTeam");
                p.HasOne(x => x.Position).WithMany(x => x.Players).HasForeignKey(x => x.PositionId).HasConstraintName("FK_PlayerPosition");
            });
            modelBuilder.Entity<PlayerStatistic>(p =>
            {
                p.HasKey(x => new { x.PlayerId, x.GameId });
                p.HasOne(x => x.Game).WithMany(x => x.PlayerStatistics).HasForeignKey(x => x.GameId).HasConstraintName("FK_GameStats");
                p.HasOne(x => x.Player).WithMany(x => x.PlayerStatistics).HasForeignKey(x => x.PlayerId).HasConstraintName("FK_PlayerStats");
            });
            modelBuilder.Entity<Game>(p =>
            {
                p.HasOne(x => x.HomeTeam).WithMany(x => x.HomeGames).HasForeignKey(x => x.HomeTeamId).HasConstraintName("FK_HomeTeamGames");
                p.HasOne(x => x.AwayTeam).WithMany(x => x.AwayGames).HasForeignKey(x => x.AwayTeamId).HasConstraintName("FK_AwayTeamGanes");
            });
            modelBuilder.Entity<Bet>(p =>
            {
                p.HasOne(x => x.Game).WithMany(x => x.Bets).HasForeignKey(x => x.GameId).HasConstraintName("FK_BetGame");
                p.HasOne(x => x.User).WithMany(x => x.Bets).HasForeignKey(x => x.UserId).HasConstraintName("FK_BetUser");
            });
            modelBuilder.Entity<User>(p =>
            {
                p.Property(x => x.Username).HasMaxLength(80).IsRequired(true);
                p.Property(x => x.Password).HasMaxLength(80).IsRequired(true);
                p.Property(x => x.Email).HasMaxLength(80).IsUnicode(false).IsRequired(true);
                p.Property(x => x.Name).HasMaxLength(150).IsRequired(false);
            });
        }
    }
}
