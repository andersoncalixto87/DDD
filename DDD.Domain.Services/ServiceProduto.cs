using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Domain.Entities;

namespace DDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto repositoryProduto;
        public ServiceProduto(IRepositoryProduto repositoryProduto) : base(repositoryProduto)
        {
            this.repositoryProduto = repositoryProduto;
        }
    }
}
