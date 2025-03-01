using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektProgramia.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }


}