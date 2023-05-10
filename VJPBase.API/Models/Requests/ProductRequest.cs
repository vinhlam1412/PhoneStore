using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests
{
    public class ProductRequest 
    { 
        [Required]
        public string Name { get; set; }


        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Id_Brand { get; set; }

    }
}
