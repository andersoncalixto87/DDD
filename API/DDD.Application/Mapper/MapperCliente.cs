using DDD.Application.DTO;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Application.Mapper
{
    public class MapperCliente : IMapperCliente
    {
        public Cliente MapperDTOToEntity(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente()
            {
                Id = clienteDTO.Id,
                Nome = clienteDTO.Nome,
                Sobrenome = clienteDTO.Sobrenome,
                Email = clienteDTO.Email

            };
            return cliente;
        }

        public ClienteDTO MapperEntitytoDTO(Cliente cliente)
        {
            var clienteDto = new ClienteDTO()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                Email = cliente.Email

            };
            return clienteDto;
        }

        public IEnumerable<ClienteDTO> MapperListClienteDTO(IEnumerable<Cliente> clientes)
        {
            var dto = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Email = c.Email

            });
            return dto;
        }
    }
}
