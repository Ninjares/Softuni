using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.App.Models
{
    public class Submission
    {
        public Submission()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [MaxLength(800)]
        [Required]
        public string Code { get; set; }
        [Range(0,300)]
        public int AchievedResult { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string ProblemId { get; set; }
        public Problem Problem { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
