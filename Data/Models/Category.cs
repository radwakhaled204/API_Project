using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{//11
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter the name")]
        [MaxLength(50 , ErrorMessage = "The Max Length is 50")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "The Max Length is 50")]
        public string? note { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        //one to many relationship with item table
        public virtual List<ApiItem> apiitem { get; set; }
    }
}
