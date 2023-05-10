using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using System.Net;

namespace VJPBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public CustomerController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listCustomer = _context.Customers.ToList();
            return Ok(listCustomer);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerRequest model)
        {
            try
            {
                var newCustomer = new Customer
                {
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    IsDeleted = false
                };
                _context.Add(newCustomer);
                _context.SaveChanges();
                return Ok(newCustomer);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerRequest model)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Address = model.Address;
                customer.Phone = model.Phone;
                _context.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                _context.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
