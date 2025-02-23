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
        public AccountController(UserManager<Users> userManager, IConfiguration configuration, IMapper mapper , IAuthRepository authRepository)
        {
             _mapper = mapper;
            _userManager = userManager;
            this.configuration = configuration;
            _authRepository = authRepository;
        }

        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        [HttpPost("registeruser")]
        public async Task<IActionResult> Register([FromBody] UserDto registerDto)
        {
            if (registerDto == null) return BadRequest("Invalid user data");

            registerDto.Email = registerDto.Email.ToLower();

            // التحقق مما إذا كان البريد الإلكتروني مستخدمًا بالفعل
            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
            {
                return BadRequest("Email already exists");
            }

            var user = new Users
            {
                UserName = registerDto.Username, // IdentityUser يحتوي على UserName
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "User registered successfully" });
        }



        //[HttpPost]
        //public async Task<IActionResult> LogIn(LoginDto login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Users? user = await _userManager.FindByNameAsync(login.userName);
        //        if (user != null)
        //        {
        //            if (await _userManager.CheckPasswordAsync(user, login.password))
        //            {
        //                var claims = new List<Claim>();
        //                //claims.Add(new Claim("name", "value"));
        //                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        //                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
        //                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //                var roles = await _userManager.GetRolesAsync(user);
        //                foreach (var role in roles)
        //                {
        //                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        //                }
        //                //signingCredentials
        //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
        //                var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //                var token = new JwtSecurityToken(
        //                    claims: claims,
        //                    issuer: configuration["JWT:Issuer"],
        //                    audience: configuration["JWT:Audience"],
        //                    expires: DateTime.Now.AddHours(1),
        //                    signingCredentials: sc
        //                    );
        //                var _token = new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(token),
        //                    expiration = token.ValidTo,
        //                };
        //                return Ok(_token);
        //            }
        //            else
        //            {
        //                return Unauthorized();
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "User Name is invalid");
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}
