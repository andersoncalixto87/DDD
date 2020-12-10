using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Domain.Entities;


namespace DDD.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente repositoryCliente;
        public ServiceCliente(IRepositoryCliente repositoryCliente) : base(repositoryCliente)
        {
            this.repositoryCliente = repositoryCliente;
        }
    }
}
