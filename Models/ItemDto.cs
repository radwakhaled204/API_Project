using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class ItemDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Enter The Name")]
        public string Name { get; set; }
        public string? Notes { get; set; }
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
