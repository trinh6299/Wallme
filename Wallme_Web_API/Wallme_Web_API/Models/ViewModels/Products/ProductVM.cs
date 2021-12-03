using System;

namespace Wallme_Web_API.Models.ViewModels.Products
{
    public class ProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public decimal SalePrice { get; set; }

        public int Inventory { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}