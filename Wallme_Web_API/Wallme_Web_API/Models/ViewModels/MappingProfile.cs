using AutoMapper;
using Wallme_Web_API.Models.ViewModels.Carts;
using Wallme_Web_API.Models.ViewModels.Categories;
using Wallme_Web_API.Models.ViewModels.Comments;
using Wallme_Web_API.Models.ViewModels.Products;

namespace Wallme_Web_API.Models.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Cart, CartVM>().ReverseMap();
            CreateMap<Comment, CommentVM>().ReverseMap();
        }
    }
}