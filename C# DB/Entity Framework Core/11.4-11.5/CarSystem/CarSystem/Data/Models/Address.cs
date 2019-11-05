using System;
using System.Collections.Generic;
using System.Text;

namespace CarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Name { get; set; }
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
