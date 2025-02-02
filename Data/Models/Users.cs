using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API_PRO.Data.Models
{
    public class Users : IdentityUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public  string UserName { get; set; }
        [Required]
        public  string Password { get; set; }



    }

}
