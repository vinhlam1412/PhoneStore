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
    public class StoreController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StoreController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listStore = _context.Stores.ToList();
            return Ok(listStore);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var store = _context.Stores.SingleOrDefault(x => x.Id == id);
            if (store != null)
            {
                return Ok(store);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateStore(StoreRequest model)
        {
            try
            {
                var newStore = new Store
                {
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    IsDeleted = false
                };
                _context.Add(newStore);
                _context.SaveChanges();
                return Ok(newStore);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StoreRequest model)
        {
            var store = _context.Stores.SingleOrDefault(x => x.Id == id);
            if (store != null)
            {
                store.Name = model.Name;
                store.Address = model.Address;
                store.Phone = model.Phone;
                _context.SaveChanges();
                return Ok(store);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var store = _context.Stores.SingleOrDefault(x => x.Id == id);
            if (store != null)
            {
                store.IsDeleted = true;
                _context.SaveChanges();
                return Ok(store);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
