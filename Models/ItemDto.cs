using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API_PRO.Models
{
    public class ItemDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Please Enter The Name")]
        public string Name { get; set; }
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Enter Suitable Price")]
        
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
