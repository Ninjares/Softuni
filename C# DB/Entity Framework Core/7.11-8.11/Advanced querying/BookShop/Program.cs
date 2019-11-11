namespace BookShop
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using BookShop.Data;
    using System.Text;
    using System.Linq;

    public class StartUp
    {
        
        static void Main(string[] args)
        {
            BookShopContext db = new BookShopContext();
            Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booknames = context.Books.Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower()).Select(x => x.Title).OrderBy(x => x).ToArray();
            return string.Join("\n", booknames);
        }
    }
}
