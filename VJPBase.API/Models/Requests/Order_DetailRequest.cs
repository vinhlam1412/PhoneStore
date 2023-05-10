using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests
{
    public class Order_DetailRequest 
    {
        [Required]
        public int Id_Product { get; set; }
        [Required]
        public int Id_Order { get; set; }
   
        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
