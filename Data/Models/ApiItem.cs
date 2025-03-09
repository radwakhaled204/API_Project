using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{
    public class ApiItem
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50 , ErrorMessage ="The Max Length is 50")]
        public string Name { get; set; }
        public string? Notes { get; set; }
        public double Price { get; set; }
        public byte[]? Image { get; set; }

        //one to many relationship with Category table
        [ForeignKey(nameof(category))]
        public int CategoryId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]

        public virtual Category category{ get; set; }
    }
}
