using DDD.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteDTO clienteDTO);
        void Update(ClienteDTO clienteDTO);
        void Remove(ClienteDTO clienteDTO);
        IEnumerable<ClienteDTO> GetAll();
        ClienteDTO GetById(int Id);
    }
}
