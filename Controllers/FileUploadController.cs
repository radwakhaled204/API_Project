using API_PRO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_PRO.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        
        public FileUploadController()
        {
            
        }
        //[HttpPost("upload-dto")]
        //public async Task<IActionResult> UploadFileWithDto([FromForm] FileUploadDto dto)
        //{
        //    if (dto.file == null || dto.file.Length == 0)
        //        return BadRequest("الملف غير موجود أو فارغ.");

        //    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

        //    if (!Directory.Exists(uploadsFolder))
        //        Directory.CreateDirectory(uploadsFolder);

        //    var filePath = Path.Combine(uploadsFolder, dto.File.FileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await dto.File.CopyToAsync(stream);
        //    }

        //    return Ok(new { Message = "تم الرفع بنجاح!", FileName = dto.File.FileName });
        //}
    }
}
