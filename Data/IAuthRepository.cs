using API_PRO.Data.Models;

namespace API_PRO.Data
{
    public interface IAuthRepository
    {

        Task<Users> Register(Users user, string password);
        //Task<Users> Login(string email, string password);
        //Task<Admin> LoginAdmin(string email, string password);
        Task<bool> UserExist(string username);
    }
}
