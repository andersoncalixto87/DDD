using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Infra.Data.Repositories
{
    class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly DDDContext dddContext;
        public RepositoryUser(DDDContext dddContext) : base(dddContext)
        {
            this.dddContext = dddContext;
        }

        public User GetUser(string Username, string Password)
        {
            User Usuario = dddContext.Usuarios.Where(u => u.Username == Username && u.Password == Password).SingleOrDefault();

            return Usuario;
 
        }
    }
}
