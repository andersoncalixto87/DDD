using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly DDDContext dddContext;
        public RepositoryCliente(DDDContext dddContext) : base(dddContext)
        {
            this.dddContext = dddContext;
        }
    }
}
