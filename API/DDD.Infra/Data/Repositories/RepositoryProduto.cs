using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly DDDContext dddContext;
        public RepositoryProduto(DDDContext dddContext) : base(dddContext)
        {
            this.dddContext = dddContext;
        }
    }
}
