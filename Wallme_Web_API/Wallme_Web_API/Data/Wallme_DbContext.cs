using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallme_Web_API.Models;

namespace Wallme_Web_API.Data
{
    public class Wallme_DbContext: IdentityDbContext<User,Role,int>
    {
        public Wallme_DbContext()
        {

        }

        public Wallme_DbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Cart_Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-I8VPSM0\\SQLEXPRESS;Database=JustBlog;Trusted_Connection=True;MultipleActiveResultSets=true");
        //        optionsBuilder.LogTo(Console.WriteLine);
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(cart =>
            {
                cart.HasKey(c => c.Id);

                cart.HasOne(c => c.User)
                    .WithMany(u => u.Carts)
                    .HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<CartItem>(cartitem =>
            {
                cartitem.HasKey(c => new { c.ProductId, c.CartId });

                cartitem.HasOne(c => c.Product)
                        .WithMany(p => p.CartItems)
                        .HasForeignKey(c => c.ProductId);

                cartitem.HasOne(c => c.Cart)
                        .WithMany(c => c.CartItems)
                        .HasForeignKey(c => c.CartId);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Comment>(comment =>
            {
                comment.HasKey(c => c.Id);

                comment.HasOne(c => c.Product)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(c => c.productId);

                comment.HasOne(c => c.User)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(p => p.Id);

                product.HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(product => product.CategoryId);
            });

            modelBuilder.Entity<ProductImage>(productImage =>
            {
                productImage.HasKey(p => p.Id);

                productImage.HasOne(p => p.Product)
                            .WithMany(p => p.ProductImages)
                            .HasForeignKey(p => p.ProductId);
            });



            base.OnModelCreating(modelBuilder);

            //Remove AspNet
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName(); if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}
