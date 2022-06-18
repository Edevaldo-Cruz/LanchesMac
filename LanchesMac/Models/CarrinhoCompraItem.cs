using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("CarrinhoCompraItem")]
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }

        /*
         Chave estrangeira:
            Para criar uma chave estrangeira basta colocar nome da tabela 
            já existente no tipo e repeti-lo.         
         */
        public Lanche Lanche { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
