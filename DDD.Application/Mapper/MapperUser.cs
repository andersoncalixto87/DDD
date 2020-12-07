using DDD.Application.DTO;
using DDD.Application.Interfaces.Mapper;
using DDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Application.Mapper
{
    public class MapperUser : IMapperUser
    {
        public MapperUser()
        {

        }
        public User MapperDTOToEntity(UserDTO userDTO)
        {
            var user = new User()
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Password = userDTO.Password,
                Role = userDTO.Role

            };
            return user;
        }

        public UserDTO MapperEntitytoDTO(User user)
        {
            var userDto = new UserDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role

            };
            return userDto;
        }

        public IEnumerable<UserDTO> MapperListUserDTO(IEnumerable<User> Users)
        {
            var dto = Users.Select(c => new UserDTO
            {
                Id = c.Id,
                Username = c.Username,
                Password = c.Password,
                Role = c.Role

            });
            return dto;
        }
    }
}
