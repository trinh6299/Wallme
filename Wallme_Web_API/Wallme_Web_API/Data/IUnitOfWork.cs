using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data.Repositories.IRepositories;

namespace Wallme_Web_API.Data
{
    public interface IUnitOfWork
    {
        ICartRepository CartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductImageRepository ProductImageRepository { get; }

        Wallme_DbContext Wallme_DbContext { get; }

        int Savechanges();
    }
}
