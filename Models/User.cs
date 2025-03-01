using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjektProgramia.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }


}