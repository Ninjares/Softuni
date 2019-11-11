namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using BookShop.Data.Models.Enums;
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } //50, uni
        public string Description { get; set; } //1000, Uni
        public DateTime? ReleaseDate { get; set; } // not req
        public int Copies { get; set; }
        public decimal Price { get; set; }
        public Edition EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();

    }
}
