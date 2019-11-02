using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Excercise.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }
        [Required]
        [Column("datetime2")]
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        [Required]
        public int PatientId { get; set; }
        public int DoctrorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
