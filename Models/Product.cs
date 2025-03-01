using System.ComponentModel.DataAnnotations;

namespace ProjektProgramia.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(550)]
        public string Description { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}