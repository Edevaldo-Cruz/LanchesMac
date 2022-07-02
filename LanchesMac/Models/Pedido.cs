using System.ComponentModel.DataAnnotations;

namespace LanchesMac.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }  
        
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [StringLength(50)]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Informe o seu endereço")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco1 { get; set; }
        
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal PedidoTotal { get; set; }
        public DateTime PedidoEnviado { get; set; }
        public DateTime? PedidoEntregueEm { get; set; }

        public List<PedidoDetalhe> PedidosItens { get; set; }
       

    }
}
