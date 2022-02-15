using System;
using FavelaDelivery;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavelaDelivery.Models
{
    public class CadastroEmpreendedor
    {
        [Key]
        public int Idempreendedor { get; set; }
        public string NomeCompleto { get; set; }
        public int CPF { get; set; }
        public string EnderecoPersonalizado { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

    }
}
