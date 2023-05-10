using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests
{
    public class StoreRequest 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
