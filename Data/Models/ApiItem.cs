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

        [MaxLength(50 , ErrorMessage ="The Max Length Is 50")]
        [Column("The_Name")]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Notes { get; set; }
        //set default value
        public double Price { get; set; } = 0;
        public byte[]? Image { get; set; }

        //one to many relationship with Category table
        [ForeignKey(nameof(category))]
        public int CategoryId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]

        public virtual Category category{ get; set; }
    }
}
