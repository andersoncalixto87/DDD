using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapperCliente mapperCliente;
        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapperCliente mapperCliente)
        {
            this.serviceCliente = serviceCliente;
            this.mapperCliente = mapperCliente;
        }
        public void Add(ClienteDTO clienteDTO)
        {
            var cliente = mapperCliente.MapperDTOToEntity(clienteDTO);
            serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = serviceCliente.GetAll();
            return mapperCliente.MapperListClienteDTO(clientes);
        }

        public ClienteDTO GetById(int Id)
        {
            var cliente = serviceCliente.GetById(Id);
            return mapperCliente.MapperEntitytoDTO(cliente);
        }

        public void Remove(ClienteDTO clienteDTO)
        {
            var cliente = mapperCliente.MapperDTOToEntity(clienteDTO);
            serviceCliente.Remove(cliente);
        }

        public void Update(ClienteDTO clienteDTO)
        {
            var cliente = mapperCliente.MapperDTOToEntity(clienteDTO);
            serviceCliente.Update(cliente);
        }
    }
}
