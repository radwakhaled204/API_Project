using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Password is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public required string Email { get; set; }
        //public string? phoneNumber { get; set; }
    }
}
