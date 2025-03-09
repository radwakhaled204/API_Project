using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace API_PRO.Data.Models
{
    public class OrderItem
    { //this table is the relation between item and order
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(orders))]
        public int OrderId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Order? orders { get; set; }

        [ForeignKey(nameof(ApiItems))]
        public int ItemId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ApiItem? ApiItems { get; set; }
        //12
        [Required(ErrorMessage ="Enter price")]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
