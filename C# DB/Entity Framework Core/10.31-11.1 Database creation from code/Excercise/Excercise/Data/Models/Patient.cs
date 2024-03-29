﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        [Required]
        public bool HasInsurance { get; set; } = false;


        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
