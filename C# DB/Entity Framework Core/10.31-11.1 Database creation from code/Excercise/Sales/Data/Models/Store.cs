using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sales.Data.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
