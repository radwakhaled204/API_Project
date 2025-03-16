using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Password Is Required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public required string Password { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public required string Email { get; set; }
        //public string? phoneNumber { get; set; }
    }
}
