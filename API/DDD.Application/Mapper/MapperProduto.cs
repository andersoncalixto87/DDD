using DDD.Application.DTO;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Application.Mapper
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDTOToEntity(ProdutoDTO produtoDTO)
        {
            var produto = new Produto()
            {
                Id = produtoDTO.Id,
                Descricao = produtoDTO.Descricao,
                Valor = produtoDTO.Valor
            };
            return produto;
        }

        public ProdutoDTO MapperEntitytoDTO(Produto produto)
        {
            var produtoDTO = new ProdutoDTO()
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Valor = produto.Valor

            };
            return produtoDTO;
        }

        public IEnumerable<ProdutoDTO> MapperListClienteDTO(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Valor = p.Valor

            });
            return dto;
        }
    }
}
