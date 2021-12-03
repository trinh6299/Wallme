using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data.Repositories;
using Wallme_Web_API.Data.Repositories.IRepositories;

namespace Wallme_Web_API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Wallme_DbContext _context;
        private ICartRepository _cartRepository;
        private ICartItemRepository _cartItemRepository;
        private ICategoryRepository _categoryRepository;
        private ICommentRepository _commentRepository;
        private IProductRepository _productRepository;
        private IProductImageRepository _productImageRepository;

        public UnitOfWork(Wallme_DbContext context)
        {
            this._context = context;
        }

        public ICartRepository CartRepository => this._cartRepository ??= new CartRepository(this._context);

        public ICartItemRepository CartItemRepository => this._cartItemRepository ??= new CartItemRepository(this._context);

        public ICategoryRepository CategoryRepository => this._categoryRepository ??= new CategoryRepository(this._context);

        public ICommentRepository CommentRepository => this._commentRepository ??= new CommentRepository(this._context);

        public IProductRepository ProductRepository => this._productRepository ??= new ProductRepository(this._context);

        public IProductImageRepository ProductImageRepository => this._productImageRepository ??= new ProductImageRepository(this._context);

        public Wallme_DbContext Wallme_DbContext => this._context;

        public int Savechanges()
        {
            return this._context.SaveChanges();
        }
    }
}
