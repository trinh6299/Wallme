using System.Collections.Generic;

namespace Wallme_Web_API.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal SalePrice { get; set; }

        public int Inventory { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}