namespace Wallme_Web_API.Models
{
    public class ProductImage : BaseModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Index { get; set; }
    }
}