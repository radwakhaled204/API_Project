using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PRO.Data.Models
{
    public class ApiItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Notes { get; set; }
        public double Price { get; set; }
        public byte[]? Image { get; set; }
        [ForeignKey(nameof(category))]
        public int CategoryId { get; set; }
        public Category category{ get; set; }
    }
}
