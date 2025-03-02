using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using static Azure.Core.HttpHeader;


namespace API_PRO.Controllers
{//12
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
        public async Task<IActionResult> AddItem([FromForm]mdlitem mdl)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> edititem(int id , [FromForm] mdlitem mdl) 
        {
            var existeditem = await _db.ApiItems.FindAsync(id);
            if (existeditem == null)
            {
                return NotFound($"id {id} not exist in data");
            }
            var categoryid = await _db.Categories.AnyAsync(x => x.Id == mdl.CategoryId);
            if (categoryid == null)
            {
                return NotFound($"id {categoryid} not exist in data");
            }
            if (mdl.Image !=null)
            {
                using var stream = new MemoryStream();
                await mdl.Image.CopyToAsync(stream);
                existeditem.Image = stream.ToArray();   
            }
            existeditem.Name = mdl.Name;
            existeditem.Price = mdl.Price;
            existeditem.Notes = mdl.Notes;
            existeditem.CategoryId = mdl.CategoryId;
            _db.SaveChanges();
            return Ok("successfully edited");
        }
        [HttpGet("itemsINcategory/{categoryid}")]
        public async Task<IActionResult> Getbycategoryid(int categoryid)
        {
            var item = await _db.ApiItems.Where(x => x.CategoryId == categoryid).ToListAsync();
            if (item == null)
            {
                return NotFound($"id {categoryid} not exist in data");
            }
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteitem(int id)
        {
            var item = await _db.ApiItems.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound($"id {id} not exist in data");
            }
             _db.ApiItems.Remove(item);
            await _db.SaveChangesAsync();
            return Ok("successfully deleted");
        }

    }
}
