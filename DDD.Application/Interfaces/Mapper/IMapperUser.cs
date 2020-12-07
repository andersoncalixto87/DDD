using DDD.Application.DTO;
using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces.Mapper
{
    public interface IMapperUser
    {
        User MapperDTOToEntity(UserDTO userDTO);
        IEnumerable<UserDTO> MapperListUserDTO(IEnumerable<User> Users);
        UserDTO MapperEntitytoDTO(User user);
    }
}
