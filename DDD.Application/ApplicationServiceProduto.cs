using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto serviceProduto;
        private readonly IMapperProduto mapperProduto;
        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
        {
            this.serviceProduto = serviceProduto;
            this.mapperProduto = mapperProduto;
        }
        public void Add(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
            serviceProduto.Add(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtos = serviceProduto.GetAll();
            return mapperProduto.MapperListClienteDTO(produtos);
        }

        public ProdutoDTO GetById(int Id)
        {
            var produto = serviceProduto.GetById(Id);
            return mapperProduto.MapperEntitytoDTO(produto);
        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
            serviceProduto.Remove(produto);
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
            serviceProduto.Update(produto);
        }
    }
}
