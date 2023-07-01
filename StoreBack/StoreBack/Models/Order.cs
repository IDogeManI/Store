using System.ComponentModel.DataAnnotations;

namespace StoreBack.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public List<Product> Products { get; set; } = null;
        public string Adress { get; set; } = null;
        public string OrderStatus { get; set; } = "Ok";

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
