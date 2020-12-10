using DDD.Application.DTO;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces.Mapper
{
    public interface IMapperProduto
    {

        Produto MapperDTOToEntity(ProdutoDTO produtoDTO);
        IEnumerable<ProdutoDTO> MapperListClienteDTO(IEnumerable<Produto> produtos);
        ProdutoDTO MapperEntitytoDTO(Produto produto);
    }
}
