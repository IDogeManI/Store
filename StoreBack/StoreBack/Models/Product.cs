using System.ComponentModel.DataAnnotations;

namespace StoreBack.Models
{
    public class Product
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        [Required]
        public float Price { get; set; } = 0;
        public Guid? OrderID { get; set; }
        public Product(string name, string description, string imageUrl, float price)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.Price = price;
        }
    }
}
