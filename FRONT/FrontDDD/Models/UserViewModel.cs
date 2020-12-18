using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontDDD.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name ="Usuário")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
