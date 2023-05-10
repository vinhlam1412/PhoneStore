using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;
using VJPBase.API.Models.Requests;
using VJPBase.Data;
using VJPBase.Data.Entities;

namespace VJPBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private SchoolDbContext _context;

        public ProductController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listProduct = _context.Products.ToList();
            return Ok(listProduct);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequest model)
        {
            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Id_Brand = model.Id_Brand,
                };
                _context.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, ProductRequest model)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                product.Id_Brand = model.Id_Brand;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.IsDeleted = true;
                _context.SaveChanges();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
