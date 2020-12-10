using DDD.Domain.Entities;

namespace DDD.Domain.Core.Interfaces.Services
{
    public interface IServiceUser : IServiceBase<User>
    {
        User GetUser(string Username, string Password);
    }
}
