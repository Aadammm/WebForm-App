using System.ComponentModel.DataAnnotations;

namespace WebForms.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int PostalCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }


}