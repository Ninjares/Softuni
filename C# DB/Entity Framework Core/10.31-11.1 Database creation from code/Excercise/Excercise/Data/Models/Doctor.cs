using System;
using System.Collections.Generic;
using System.Text;

namespace Excercise.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Specialty { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
