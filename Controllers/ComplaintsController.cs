using Microsoft.AspNetCore.Mvc;

namespace API_PRO.Controllers
{
    public class ComplaintsController : Controller
    {
        //ComplaintsController private readonly IComplaintsRepo repo;

        //public ComplaintsController(IComplaintsRepo repo)
        //{
        //    this.repo = repo;
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(await repo.GetAll());
        //    }
        //    return BadRequest(ModelState);
        //}
        //[HttpGet("GetById")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            return Ok(await repo.GetById(id));
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(ComplaintsDTO complaintsDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int numOfrow = await repo.Create(complaintsDto);
        //        if (numOfrow > 0)
        //        {
        //            return Ok("Added");
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    return BadRequest(ModelState);
        //}
        //[HttpPatch]
        //public async Task<IActionResult> Update(int id, ComplaintsDTO complaintsDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            return Ok(await repo.Update(id, complaintsDto));
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int numOfRow = await repo.Delete(id);
        //            if (numOfRow > 0)
        //            {
        //                return Ok("Deleted");
        //            }
        //            return BadRequest(ModelState);
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}
