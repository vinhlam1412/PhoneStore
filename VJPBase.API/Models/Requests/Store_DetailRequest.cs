using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests
{
    public class Store_DetailRequest 
    {
        [Required]
        public int Id_Product { get; set; }

        [Required]
        public int Id_Store { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
