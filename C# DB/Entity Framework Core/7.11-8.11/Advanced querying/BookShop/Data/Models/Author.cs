namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } //max 50, uni, not req
        public string LastName { get; set; } //max 50, uni, req

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
