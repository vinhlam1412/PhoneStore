using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;

namespace VJPBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public BrandController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listProduct = _context.Brands.ToList();
            return Ok(listProduct);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brand = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (brand != null)
            {
                return Ok(brand);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateBrand(BrandRequest model)
        {
            try
            {
                var newBrand = new Brand
                {
                    Name = model.Name,
                    IsDeleted = false
                };
                _context.Add(newBrand);
                _context.SaveChanges();
                return Ok(newBrand);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BrandRequest model)
        {
            var brand = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (brand != null)
            {
                brand.Name = model.Name;
                _context.SaveChanges();
                return Ok(brand);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (brand != null)
            {
                brand.IsDeleted = true;
                _context.SaveChanges();
                return Ok(brand);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
