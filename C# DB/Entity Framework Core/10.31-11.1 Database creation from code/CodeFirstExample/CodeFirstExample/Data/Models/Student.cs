using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstExample.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bumpas")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Column("char(10)")]
        public string EGN { get; set; }
        public int? Age { get; set; } //Can't allow nulls without ?
        [NotMapped]
        public string FullName 
        {
            get
            {
                if (MiddleName == null)
                    return $"{FirstName} {LastName}";
                return $"{FirstName} {MiddleName} {LastName}";
            }

        }
        
        public int TownId { get; set; }
        public Town Town { get; set; }

        public DateTime registrationDate { get; set; }
        public StudentType? Type { get; set; } //Any datatype which does not have a null by default needs ? to allow nulls
    }
}
