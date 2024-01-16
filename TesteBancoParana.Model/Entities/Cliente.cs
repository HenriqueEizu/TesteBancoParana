using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBancoParana.Model.Entities
{
    public  class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage ="Nome do cliente é obrigatório")]
        public string nomeCliente { get; set; }

        public string email { get; set; }

        public List<Telefones> telefones { get; set;}
    }
}
