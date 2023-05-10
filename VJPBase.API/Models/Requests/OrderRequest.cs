using System;
using System.ComponentModel.DataAnnotations;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Requests
{
    public  class OrderRequest 
    {
        [Required]
        public int Id_Customer { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        public int Id_Product { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
