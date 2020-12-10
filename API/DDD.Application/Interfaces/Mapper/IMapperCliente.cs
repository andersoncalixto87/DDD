using DDD.Application.DTO;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces.Mapper
{
    public interface IMapperCliente
    {
        Cliente MapperDTOToEntity(ClienteDTO clienteDTO);
        IEnumerable<ClienteDTO> MapperListClienteDTO(IEnumerable<Cliente> clientes);
        ClienteDTO MapperEntitytoDTO(Cliente cliente);
    }
}
