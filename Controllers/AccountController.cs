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
    {//2
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
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LoginDto logindto)
        {
            if (ModelState.IsValid)
            {
               Users?  user = await _userManager.FindByNameAsync(logindto.userName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, logindto.password))
                    {
                        var claims = new List<Claim>();
                        //claims.Add(new Claim("name", "value"));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //add role 
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }

                        //signingCredentials
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );


                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name is invalid");
                }
            }
            return BadRequest(ModelState);
        }

    }
}
