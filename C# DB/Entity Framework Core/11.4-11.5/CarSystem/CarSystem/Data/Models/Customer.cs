using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarSystem.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
