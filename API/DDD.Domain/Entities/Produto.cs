using System;

namespace DDD.Domain.Entities
{
    public class Produto : Base
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool IsDisponivel { get; set; }
        public DateTime DataCadastro { get; set; }
        
    }
}
