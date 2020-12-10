using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int Id)
        {
            return repository.GetById(Id);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
