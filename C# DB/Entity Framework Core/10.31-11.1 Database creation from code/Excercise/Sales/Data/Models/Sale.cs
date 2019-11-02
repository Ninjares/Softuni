using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sales.Data.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
