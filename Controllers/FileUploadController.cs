using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace API_PRO.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IDataRepository<Files> _filerepo;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _map;

        public FileUploadController(IDataRepository<Files> filerepo, IWebHostEnvironment env , IMapper map)
        {
            _filerepo = filerepo;
            _env = env;
            _map = map;

        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadDto filedto)
        {
            if (filedto.file == null || filedto.file.Length == 0)
                return BadRequest("الملف غير موجود.");

     
            if (string.IsNullOrEmpty(_env.WebRootPath))
            {
                _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var filefolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(filefolder))
            {
                Directory.CreateDirectory(filefolder);
            }

           
            var uniqueFileName = $"{Guid.NewGuid()}_{filedto.file.FileName}";
            var filepath = Path.Combine(filefolder, uniqueFileName);

      
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await filedto.file.CopyToAsync(stream);
            }

          
            var fileRecord = new Files
            {
                FileName = filedto.file.FileName, 
                FilePath = $"/uploads/{uniqueFileName}", 
                SubjectId = filedto.subid           
            };

            await _filerepo.AddFun(fileRecord); 

            return Ok(new { message = "تم تحميل الملف بنجاح.", path = fileRecord.FilePath });
        }



        [HttpGet("download/{FileName}")]
        public async Task<IActionResult> Download(string FileName)
        {
            var filepath = Path.Combine("wwwroot/uploads" , FileName);
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }
            var filebyte = await System.IO.File.ReadAllBytesAsync(filepath);
            
            return File(filebyte ,"application/pdf" , FileName);
        }


    }
}
