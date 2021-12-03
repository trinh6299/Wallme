using System.Collections.Generic;
using Wallme_Web_API.Constant;

namespace Wallme_Web_API.Models
{
    public class Cart : BaseModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal SumPrice { get; set; }

        public CartStatus Status { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}