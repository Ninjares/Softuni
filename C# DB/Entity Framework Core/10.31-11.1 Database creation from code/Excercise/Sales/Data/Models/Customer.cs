using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sales.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } //unicode
        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
