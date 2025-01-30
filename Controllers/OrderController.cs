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


        [HttpGet("one/{orderId:int}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _db.Orders.Where(x => x.id == orderId).FirstOrDefaultAsync();
            if (order != null)
            {
                dtoOrders dto = new()
                {
                    orderId = order.id,
                    OrderDate = order.CreatedDate,
                };
                if (order.ordersItems != null && order.ordersItems.Any())
                {
                    foreach (var item in order.ordersItems)
                    {
                        dtoOrdersItems dtoItem = new()
                        {
                            itemId = item.items.Id,
                            itemName = item.items.Name,
                            price = item.Price,
                            quantity = 1,
                        };
                        dto.items.Add(dtoItem);
                    }
                }
                return Ok(dto);
            }
            return NotFound($"The Order Id {orderId} not Exists");
        }



        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            return Ok(order);
        }
    }
}
