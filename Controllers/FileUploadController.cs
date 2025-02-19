using API_PRO.Data;
using API_PRO.Data;
using API_PRO.Data.Models;
using API_PRO.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace API_PRO.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IDataRepository<Files> _filerepo;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _map;

        public FileUploadController(IDataRepository<Files> filerepo, IHostingEnvironment env , IMapper map)
        {
            _filerepo = filerepo;
            _env = env;
            _map = map;

        }
        [HttpPost("upload")]
        public async Task<IActionResult> upload([FromForm] FileUploadDto filedto)
        {
            if (filedto.file == null || filedto.file.Length == 0)
                return BadRequest("file is null");
            var filefolder = Path.Combine(_env.WebRootPath ,"uploads");
            if (!Directory.Exists(filefolder))
            { 
                Directory.CreateDirectory(filefolder);
            }
            var filepath = Path.Combine(filefolder,filedto.file.FileName);
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await filedto.file.CopyToAsync(stream);
            }
            return Ok();
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
