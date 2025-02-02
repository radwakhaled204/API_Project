using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class dtoOrders
    {
        public int orderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }


        public ICollection<dtoOrdersItems> ApiItems { get; set; } = new List<dtoOrdersItems>();
    }

    public class dtoOrdersItems
    {
        [Required]
        public int itemId { get; set; }
        public string? itemName { get; set; }

        [Required]
        public decimal price { get; set; }

    }
}