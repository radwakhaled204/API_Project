using API_PRO.Data.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace API_PRO.Data
{
    public class AuthRepository : IAuthRepository
    {

     
        private readonly UserManager<Users> _userManager;
        public AuthRepository(UserManager<Users> userManager)
        {
          
            _userManager = userManager;
        }

        //public async Task<Admin> LoginAdmin(string email, string password)
        //{
        //    var admin = await _db.Admin.FirstOrDefaultAsync(u => u.Email == email);
        //    if (admin == null || !VerifyPassword(password, admin.PasswordHash, admin.PasswordSalt))
        //    {
        //        return null;
        //    }
        //    return admin;
        //}

        //public async Task<User> Login(string email, string password)
        //{
        //    var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);
        //    if (user == null || !VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return null;
        //    }
        //    return user;
        //}


        public async Task<Users?> Register(Users user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return null; 
            }

            return user;
        }

        public async Task<bool> UserExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}

