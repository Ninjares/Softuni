using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Excercise.Data.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        [Required]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
