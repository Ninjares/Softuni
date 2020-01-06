using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Range(typeof(Decimal), "0,01", "1000000000000")]
        public decimal Price { get; set; }
        [Range(50,5000)]
        public int Pages { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
