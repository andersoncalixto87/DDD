using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        User GetUser(string Username, string Password);
    }
}
