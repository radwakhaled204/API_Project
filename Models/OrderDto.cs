

namespace API_PRO.Models
{
    public class OrderDto
    {
        public DateTime CreatedDate { set; get; }
        public virtual ICollection<OrderItemsDto>? ordersItems { get; set; }

    }

    public class OrderItemsDto
    {
        public string? itemName { get; set; }
        public DateTime createdDate { get; set; }
    }
}