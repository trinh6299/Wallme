using Wallme_Web_API.Constant;

namespace Wallme_Web_API.Models.ViewModels.Carts
{
    public class CartVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal SumPrice { get; set; }

        public CartStatus Status { get; set; }
    }
}