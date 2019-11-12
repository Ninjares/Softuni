namespace BookShop
{
    using Data;
    using Initializer;
    using System.Linq;
    using System;
    using System.Text;
    using BookShop.Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                Console.WriteLine(RemoveBooks(db));
            }
        }
        #region Homework
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            var booknames = context.Books.Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower()).Select(x => x.Title).OrderBy(x => x).ToArray();
            foreach (string bookname in booknames) sb.AppendLine(bookname);
            return sb.ToString();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in context.Books.Where(x => x.EditionType.ToString() == "Gold" && x.Copies < 5000).OrderBy(x => x.BookId))
                sb.AppendLine(book.Title);
            return sb.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in context.Books.Where(x => x.Price > 40m).Select(x => new { BookTitle = x.Title, Price = x.Price }).OrderByDescending(x => x.Price))
                sb.AppendLine($"{book.BookTitle} - ${book.Price}");
            return sb.ToString().Trim();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year != year).OrderBy(x => x.BookId).Select(x => x.Title).ToArray();
            foreach (string book in books) sb.AppendLine(book);
            return sb.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split();
            StringBuilder sb = new StringBuilder();
            foreach (var book in context.Books.Where(x => x.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower()))).OrderBy(x => x.Title))
                sb.AppendLine(book.Title);
            return sb.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books.Where(x => x.ReleaseDate < DateTime.Parse(date)).OrderByDescending(x => x.ReleaseDate);
            foreach (var book in books)
                sb.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price}");
            return sb.ToString().Trim();
        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var author in context.Authors.Where(x => x.FirstName.EndsWith(input)).Select(x => x.FirstName + ' ' + x.LastName).OrderBy(x => x))
                sb.AppendLine(author);
            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in context.Books.Where(x => x.Title.ToLower().Contains(input.ToLower())).OrderBy(x => x.Title))
                sb.AppendLine(book.Title);
            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining2(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var book in BookTitlesContaining(context, input))
                sb.AppendLine(book.Title);
            return sb.ToString().Trim();
        }
        public static Func<BookShopContext, string, IEnumerable<Book>> BookTitlesContaining
            = EF.CompileQuery<BookShopContext, string, IEnumerable<Book>>((db, input) =>
                db.Books.Where(x => x.Title.ToLower().Contains(input.ToLower())).OrderBy(x => x.Title));

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var books = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower())).OrderBy(x => x.BookId).Select(x => new
            {
                x.Title,
                AuthorName = x.Author.FirstName + " " + x.Author.LastName
            });
            foreach (var book in books)
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(x => x.Title.Length > lengthCheck).Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authorCopies = context.Authors.Select(a => new
            {
                Name = a.FirstName + " " + a.LastName,
                Copies = a.Books.Sum(x => x.Copies)

            }).OrderByDescending(x => x.Copies);
            foreach (var author in authorCopies)
                sb.AppendLine($"{author.Name} - {author.Copies}");
            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categoryProfit = context.Categories.Select(x => new
            {
                x.Name,
                Profit = x.CategoryBooks.Sum(z => z.Book.Price * z.Book.Copies)
            }).OrderByDescending(x => x.Profit).ThenBy(x => x.Name);
            foreach (var category in categoryProfit)
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var recentbooks = context.Categories.OrderBy(x => x.Name).Select(c => new
            {
                c.Name,
                Books = c.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate).Take(3).Select(b => new
                {
                    b.Book.Title,
                    Year = b.Book.ReleaseDate.Value.Year
                })
            });
            foreach(var category in recentbooks)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                    sb.AppendLine($"{book.Title} ({book.Year})");
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var bookstoPump = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010);
            foreach (var book in bookstoPump) book.Price += 5m;
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books.Where(x => x.Copies < 4200);
            int count = booksToRemove.Count();
            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();
            return count;
        }
        #endregion
    }
}
