namespace CarSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
