using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBancoParana.Model.Entities
{
    public class Telefones
    {
        [Key]
        public int idTelefone { get; set; }

        public int ClienteidCliente { get; set; }

        [Range(11, 99, ErrorMessage = "Codigo do estado incorreto")]
        public int ddd { get; set; }


        [Range(1, 999999999, ErrorMessage = "Número do celular no formato incorreto")]
        public int numero { get; set; }

        public EnumTipoTelefone tipoTelefone { get; set; }
    }
}
