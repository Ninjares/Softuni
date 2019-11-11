namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using BookShop.Data.Models;
    public class BookShopContext : DbContext
    {
        public BookShopContext() { }
        public BookShopContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BookShop;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(a => {
                a.Property(x => x.FirstName).HasMaxLength(50).IsRequired(false).IsUnicode(true);
                a.Property(x => x.LastName).HasMaxLength(50).IsUnicode(true).IsUnicode(true);
                a.HasKey(x => x.AuthorId);
            });
            modelBuilder.Entity<Category>(a =>
            {
                a.Property(x => x.Name).HasMaxLength(50).IsRequired(true).IsUnicode(true);
                a.HasKey(x => x.CategoryId);
            });
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.BookId);
                b.Property(x => x.Title).HasMaxLength(50).IsUnicode(true).IsRequired(true);
                b.Property(x => x.Description).HasMaxLength(1000).IsRequired(false).IsUnicode();
                b.Property(x => x.ReleaseDate).IsRequired(false);
                b.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId).HasConstraintName("FK_BookAuthor");
            });
            modelBuilder.Entity<BookCategory>(bc =>
            {
                bc.HasKey(x => new { x.BookId, x.CategoryId });
                bc.HasOne(x => x.Book).WithMany(x => x.BookCategories).HasForeignKey(x => x.BookId);
                bc.HasOne(x => x.Category).WithMany(x => x.BookCategories).HasForeignKey(x => x.CategoryId);
            });
        }
    }
}
