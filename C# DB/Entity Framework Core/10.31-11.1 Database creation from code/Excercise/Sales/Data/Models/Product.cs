using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sales.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } //unicode

        public uint Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
   }
}
