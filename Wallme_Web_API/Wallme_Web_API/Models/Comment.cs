using System.ComponentModel.DataAnnotations;

namespace Wallme_Web_API.Models
{
    public class Comment : BaseModel
    {
        public int Id { get; set; }

        public int productId { get; set; }

        public Product Product { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Content { get; set; }
    }
}