using DDD.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(UserDTO userDTO);
        void Update(UserDTO userDTO);
        void Remove(UserDTO userDTO);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int Id);
        UserDTO GetUser(string Username, string Password);
    }
}
