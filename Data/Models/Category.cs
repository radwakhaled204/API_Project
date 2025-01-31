using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using System.Text.Json.Serialization;

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
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual List<ApiItem> apiitem { get; set; }
    }
}
