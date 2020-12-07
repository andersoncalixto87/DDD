using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DDD.Application.DTO;
using DDD.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace DDD.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IApplicationServiceCliente applicationServiceCliente;
        public ClienteController(IApplicationServiceCliente applicationServiceCliente)
        {
            this.applicationServiceCliente = applicationServiceCliente;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceCliente.GetAll());
        }
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<string>> Get(int Id)
        {
            return Ok(applicationServiceCliente.GetById(Id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                {
                    return NotFound();
                }

                applicationServiceCliente.Add(clienteDTO);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                {
                    return NotFound();
                }

                applicationServiceCliente.Update(clienteDTO);
                return Ok("Cliente Atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                {
                    return NotFound();
                }

                applicationServiceCliente.Remove(clienteDTO);
                return Ok("Cliente Removido com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
