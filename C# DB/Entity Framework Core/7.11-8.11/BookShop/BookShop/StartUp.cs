namespace BookShop
{
    using Data;
    using Initializer;
    using System.Linq;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine())));
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            var booknames = context.Books.Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower()).Select(x => x.Title).OrderBy(x => x).ToArray();
            foreach (string bookname in booknames) sb.AppendLine(bookname);
            return sb.ToString();
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
            return sb.ToString();
        }
    }
}
