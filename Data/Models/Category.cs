using System.ComponentModel.DataAnnotations;

namespace API_PRO.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? note { get; set; }    
    }
}
