using DDD.API.Services;
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
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser applicationServiceUser;
        public UserController(IApplicationServiceUser applicationServiceUser)
        {
            this.applicationServiceUser = applicationServiceUser;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceUser.GetAll());
        }

        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<string>> Get(int Id)
        {
            return Ok(applicationServiceUser.GetById(Id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return NotFound();
                }

                applicationServiceUser.Add(userDTO);
                return Ok("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return NotFound();
                }

                applicationServiceUser.Update(userDTO);
                return Ok("Usuário Atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return NotFound();
                }

                applicationServiceUser.Remove(userDTO);
                return Ok("Usuário Removido com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login([FromBody] UserDTO userDTO)
        {

            var user = applicationServiceUser.GetUser(userDTO.Username, userDTO.Password);
            if(user == null)
            {
                return NotFound( new { message = "Usuário não encontrado"});
            }
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token

            };
        }
    }
}
