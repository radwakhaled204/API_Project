using API_PRO.Data;
using API_PRO.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        public OrderController(AppDbContext db) 
        {
            _db = db;
        }
        private readonly AppDbContext _db;
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = _db.Orders.Include(t => t.ordersItems).ThenInclude(t => t.items);
  
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            return Ok(order);
        }
    }
}
