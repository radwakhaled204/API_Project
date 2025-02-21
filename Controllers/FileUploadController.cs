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
