using System.Collections.Generic;
using Wallme_Web_API.Models;

namespace Wallme_Web_API.Data.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseModel
    {
        IEnumerable<TEntity> GetAll(bool isDeleted = false);

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id, bool isDeleted = false);
    }
}