using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Entities
{
    public class User : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
