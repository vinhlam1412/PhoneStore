using System.ComponentModel.DataAnnotations;

namespace VJPBase.API.Models.Requests
{
    public class BrandRequest 
    {
        [Required]
        public string Name { get; set; }
    }
}
