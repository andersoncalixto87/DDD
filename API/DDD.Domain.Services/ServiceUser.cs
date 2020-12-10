using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Domain.Entities;

namespace DDD.Domain.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser repositoryUser;
        public ServiceUser(IRepositoryUser repositoryUser) : base(repositoryUser)
        {
            this.repositoryUser = repositoryUser;
        }

        public User GetUser(string Username, string Password)
        {
            return repositoryUser.GetUser(Username,Password);
        }
    }
}
