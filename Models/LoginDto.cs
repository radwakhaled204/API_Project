using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{

    public class LoginDto
    {
        [Required(ErrorMessage = "enter the name")]
        public string userName { get; set; }

       [Required]
      public string password { get; set; }
    }
}