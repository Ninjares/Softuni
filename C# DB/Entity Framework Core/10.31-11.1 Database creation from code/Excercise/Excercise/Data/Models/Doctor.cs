using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Specialty { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
