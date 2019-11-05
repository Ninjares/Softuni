using System;

namespace CarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [MaxLength(30)]
        public string Vin { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public Sale Sale { get; set; }
    }
}
