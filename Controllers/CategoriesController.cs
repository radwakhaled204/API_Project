using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API_PRO.Data.Models;
using Microsoft.EntityFrameworkCore;
using API_PRO.Data;
using Azure;
using Microsoft.AspNetCore.JsonPatch;


namespace API_PRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork<Category> _uow;
        public CategoriesController(IUnitOfWork<Category> uow)
        {
            _uow = uow;
        }
        

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var c = await _uow.categories.GetAllFun();
            return Ok(c);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Getbyid(int id)
        //{
        //    var c = await _uow.Categories.SingleOrDefaultAsync(x => x.Id == id);
        //    if (c == null)
        //    {
        //        return NotFound($"Category Id {id} not found");
        //    }

        //    return Ok(c);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddCategory(string category)
        //{
        //    Category c = new Category { Name = category };
        //    await _uow.Categories.AddAsync(c);
        //    _uow.SaveChanges();
        //    return Ok(c);
        //}
        //[HttpPut]
        //public async Task<IActionResult> PutCategory(Category category)
        //{
        //    var c = await _uow.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
        //    if (c ==null)
        //    {
        //        return NotFound($"Category Id {category.Id} not found");
        //    }
        //    c.Name = category.Name;
        //    _uow.SaveChanges();
        //    return Ok(c);
        //}
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> patchcategory([FromBody] JsonPatchDocument<Category> category , [FromRoute] int id)
        //{
        //    var c = await _uow.Categories.SingleOrDefaultAsync(x=> x.Id == id);
        //    if (c ==null)
        //    {
        //        return NotFound($"Category Id {id} not found");
        //    }
        //    category.ApplyTo(c);
        //    _db.SaveChanges();
        //    return Ok(c);
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
        //    if (c == null)
        //    {
        //        return NotFound($"Category Id {id} not found");
        //    }
        //    _db.Categories.Remove(c);
        //    _db.SaveChanges();
        //    return Ok(c);
        //}
    }
}
