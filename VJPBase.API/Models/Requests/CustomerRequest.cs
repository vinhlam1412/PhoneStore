using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests
{
    public class CustomerRequest 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
