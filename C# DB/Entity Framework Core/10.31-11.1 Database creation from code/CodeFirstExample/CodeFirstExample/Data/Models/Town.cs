using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstExample.Data.Models
{
    public class Town
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
