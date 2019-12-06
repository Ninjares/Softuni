﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }
        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
