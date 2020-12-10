using DDD.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO produtoDTO);
        void Update(ProdutoDTO produtoDTO);
        void Remove(ProdutoDTO produtoDTO);
        IEnumerable<ProdutoDTO> GetAll();
        ProdutoDTO GetById(int Id);
    }
}
