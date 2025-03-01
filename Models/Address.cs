using System.ComponentModel.DataAnnotations;

namespace ProjektProgramia.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }


}