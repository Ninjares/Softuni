using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        public Trip()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new HashSet<UserTrip>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        [Range(2,6)]
        public int Seats { get; set; }
        [MaxLength(80)]
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<UserTrip> UserTrips { get; set; }
    }
}
