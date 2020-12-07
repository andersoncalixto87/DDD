using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser serviceUser;
        private readonly IMapperUser mapperUser;
        public ApplicationServiceUser(IServiceUser serviceUser, IMapperUser mapperUser)
        {
            this.serviceUser = serviceUser;
            this.mapperUser = mapperUser;
        }

        public void Add(UserDTO userDTO)
        {
            var user = mapperUser.MapperDTOToEntity(userDTO);
            serviceUser.Add(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = serviceUser.GetAll();
            return mapperUser.MapperListUserDTO(users);
        }

        public UserDTO GetById(int Id)
        {
            var user = serviceUser.GetById(Id);
            return mapperUser.MapperEntitytoDTO(user);
        }

        public UserDTO GetUser(string Username, string Password)
        {
            var user = serviceUser.GetUser(Username, Password);
            if (user == null)
                return null;
            return mapperUser.MapperEntitytoDTO(user);
        }

        public void Remove(UserDTO userDTO)
        {
            var user = mapperUser.MapperDTOToEntity(userDTO);
            serviceUser.Remove(user);
        }

        public void Update(UserDTO userDTO)
        {
            var user = mapperUser.MapperDTOToEntity(userDTO);
            serviceUser.Update(user);
        }
    }
}
