using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VJPBase.API.Models.Requests;
using VJPBase.Data.Entities;
using VJPBase.Data;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace VJPBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public OrderController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listOrder = _context.Orders.ToList();
            return Ok(listOrder);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderRequest order)
        {
            try
            {
                var newOrder = new Order
                {
                    Id_Customer = order.Id_Customer,
                    OrderDate = DateTime.Now,
                    IsDeleted = false
                };
                _context.Add(newOrder);
                _context.SaveChanges();
                var idOrder = _context.Orders.LastOrDefault();
                var findOrder = _context.Orders.Where(x => x.Id == idOrder.Id).First();
                var newOrder_Detail = new Order_Detail
                {
                    Id_Order = findOrder.Id,
                    Id_Product = order.Id_Product,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    IsDeleted = false
                };

                _context.Add(newOrder_Detail);
                _context.SaveChanges();
                return Ok(newOrder);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order != null)
            {
                order.IsDeleted = true;
                _context.SaveChanges();
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
