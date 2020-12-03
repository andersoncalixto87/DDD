using DDD.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DDDContext dddContext;
        public RepositoryBase(DDDContext dddContext)
        {
            this.dddContext = dddContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                dddContext.Set<TEntity>().Add(obj);
                dddContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dddContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return dddContext.Set<TEntity>().Find(Id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                dddContext.Set<TEntity>().Remove(obj);
                dddContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                dddContext.Entry(obj).State = EntityState.Modified;
                dddContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
