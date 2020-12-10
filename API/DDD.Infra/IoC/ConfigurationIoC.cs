using Autofac;
using DDD.Application;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Mapper;
using DDD.Application.Mapper;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Domain.Services;
using DDD.Infra.Data.Repositories;

using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();
            builder.RegisterType<MapperUser>().As<IMapperUser>();
        }

    }
}
