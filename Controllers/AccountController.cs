using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using API_PRO.Models;
using API_PRO.Data.Models;
using API_PRO.Data;

namespace API_PRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<Users> userManager, IConfiguration configuration, IMapper mapper )
        {
             _mapper = mapper;
            _userManager = userManager;
            this.configuration = configuration;
      
        }

        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;
 


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto regdto)
        {
            if (regdto == null) return BadRequest("Please Full Form");
            regdto.Email = regdto.Email.ToLower();
            var exsist = await _userManager.FindByEmailAsync(regdto.Email);
            if (exsist != null)
            {
                return BadRequest("Email is already Exsist");
            }
            var user = new Users
            {
                UserName=regdto.Username,
                Email=regdto.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, regdto.Password);
            if (result.Succeeded)
            {
                return Ok("success");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return BadRequest(ModelState);
        }

        
    }
}
