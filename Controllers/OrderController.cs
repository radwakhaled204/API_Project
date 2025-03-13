using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PRO.Controllers
{//OrderController
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
            var orders = _db.Orders.Include(t => t.ordersItems).ThenInclude(t => t.ApiItems);

            return Ok(orders);
        }


        //[HttpGet("one/{orderId}")]
        //public async Task<IActionResult> GetOrderById(int orderId)
        //{
        //    var order = await _db.Orders.Where(x => x.id == orderId).FirstOrDefaultAsync();
        //    if (order != null)
        //    {
        //        dtoOrders dto = new ()
        //        {
        //            orderId = order.id,
        //            OrderDate = order.CreatedDate,
        //        };
        //        if (order.ordersItems != null && order.ordersItems.Any())
        //        {
        //            foreach (var item in order.ordersItems) {

        //                dtoOrdersItems dtoitems = new()
        //                {
        //                    itemId = item.items.Id,
        //                    itemName=item.items.Name,
        //                    price=item.Price,
        //                };
        //                dto.items.Add(dtoitems);
        //            }
        //        }

        //        return Ok(order);
        //    }
        //    return NotFound($"order id {orderId} not existe ");
        //}
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
                            itemId = item.ApiItems.Id,
                            itemName = item.ApiItems.Name,
                            price = item.Price,
                           
                        };
                        dto.ApiItems.Add(dtoItem);
                    }
                }
                return Ok(dto);
            }
            return NotFound($"The Order Id {orderId} not Exists");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] dtoOrders order)
        {
            if (ModelState.IsValid)
            {
                Order mdl = new()
                {
                    CreatedDate = order.OrderDate,
                    ordersItems = new List<OrderItem>()
                };
                foreach (var item in order.ApiItems)
                {
                    OrderItem orderItem = new()
                    {
                        ItemId = item.itemId,
                        Price = item.price,
                    };
                    mdl.ordersItems.Add(orderItem);
                }
                await _db.Orders.AddAsync(mdl);
                await _db.SaveChangesAsync();
                order.orderId = mdl.id;
                return Ok(order);
            }
            return BadRequest();
        }
    }
}

