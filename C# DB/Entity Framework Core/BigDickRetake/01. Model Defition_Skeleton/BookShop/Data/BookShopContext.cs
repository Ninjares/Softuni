namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

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
            modelBuilder.Entity<AuthorBook>(ab =>
            {
                ab.HasKey(x => new { x.BookId, x.AuthorId});
                ab.HasOne(x => x.Author).WithMany(x => x.AuthorsBooks).HasForeignKey(x => x.AuthorId);
                ab.HasOne(x => x.Book).WithMany(x => x.AuthorsBooks).HasForeignKey(x => x.BookId);
            });
        }
    }
}