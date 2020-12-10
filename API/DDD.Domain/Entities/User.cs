using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Entities
{
    public class User : Base
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
