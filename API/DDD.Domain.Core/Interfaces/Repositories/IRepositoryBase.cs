using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
    }
}
