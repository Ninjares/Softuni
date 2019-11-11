namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } //50, uni, req
        public ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();
        
    }
}
