using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{//12
    public class Order
    {
        [Key]
        public int id { get; set; }
        public DateTime CreatedDate { set; get; }
        
        [JsonIgnore]
        [IgnoreDataMember]
        //many to many relationship order with item table
        public virtual ICollection<OrderItem>? ordersItems { get; set; }
    }
}
