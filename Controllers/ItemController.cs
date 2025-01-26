using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;


namespace API_PRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        public ItemController (AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var items = await _db.ApiItems.ToListAsync();

            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var item = await _db.ApiItems.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound($"id {id} not exist in data");
            }
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(mdlitem mdl)
        {
            var stream = new MemoryStream();
            await mdl.Image.CopyToAsync(stream);
            var item = new ApiItem
            {
                Name = mdl.Name,
                Price = mdl.Price,
                Notes = mdl.Notes,
                CategoryId = mdl.CategoryId,
                Image = stream.ToArray()
            };
            await _db.ApiItems.AddAsync(item);
            _db.SaveChanges();
            return Ok(item);
        }

    }
}
