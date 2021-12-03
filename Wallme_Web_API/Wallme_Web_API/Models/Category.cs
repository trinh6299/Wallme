using System.Collections.Generic;

namespace Wallme_Web_API.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}