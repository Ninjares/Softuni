﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
