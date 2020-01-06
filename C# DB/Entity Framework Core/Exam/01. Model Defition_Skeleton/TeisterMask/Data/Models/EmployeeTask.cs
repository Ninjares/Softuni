using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Key]
        [Required]
        [ForeignKey("FK_EmployeeTask")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Key]
        [Required]
        [ForeignKey("FK_TaskEmployee")]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
