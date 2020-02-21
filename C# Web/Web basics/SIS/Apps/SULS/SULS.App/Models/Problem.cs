using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.App.Models
{
    public class Problem
    {
        public Problem()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Range(50,300)]
        public int Points { get; set; }
    }
}
