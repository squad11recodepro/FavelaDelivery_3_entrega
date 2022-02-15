using System.ComponentModel.DataAnnotations;

namespace FavelaDelivery.Models
{
    public class Contato
    {
       
        public int Nome { get; set; }   
        [Key]
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Mensagem { get; set; }
       

    }
}
