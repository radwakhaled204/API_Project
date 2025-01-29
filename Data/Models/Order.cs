using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public DateTime CreatedDate { set; get; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderItem>? ordersItems { get; set; }
    }
}
