using DDD.Application.DTO;
using DDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto applicationServiceProduto;
        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            this.applicationServiceProduto = applicationServiceProduto;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceProduto.GetAll());
        }
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<string>> Get(int Id)
        {
            return Ok(applicationServiceProduto.GetById(Id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                {
                    return NotFound();
                }

                applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                {
                    return NotFound();
                }

                applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto Atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                {
                    return NotFound();
                }

                applicationServiceProduto.Remove(produtoDTO);
                return Ok("Produto removido com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
