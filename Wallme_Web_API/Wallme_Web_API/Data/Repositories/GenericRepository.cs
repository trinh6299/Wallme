using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wallme_Web_API.Data.Repositories.IRepositories;
using Wallme_Web_API.Models;

namespace Wallme_Web_API.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseModel
    {
        protected readonly Wallme_DbContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(Wallme_DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(int id, bool isDeleted = false)
        {
            var entityExisting = this.dbSet.Find(id);
            if (entityExisting != null)
            {
                if (isDeleted == false)
                {
                    entityExisting.IsDeleted = true;
                    return;
                }
                this.dbSet.Remove(entityExisting);
            }
        }

        public IEnumerable<TEntity> GetAll(bool isDeleted = false)
        {
            if (isDeleted == false)
            {
                return this.dbSet.Where(x => x.IsDeleted == false);
            }
            return this.dbSet;
        }

        public TEntity GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }
    }
}