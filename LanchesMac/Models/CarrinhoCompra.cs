using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        // Metodo para obter ou criar um carrinho (ID)
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // Obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("Carrinho") ?? Guid.NewGuid().ToString();

            // Atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            // Retorna o carrinho com contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        // Metodo adiciona um objeto tipo lanche no carrinho
        public void AdionarAoCarrinho(Lanche lanche)
        {
            // Verifica se o lanche existe no carrinho
            var carrinhoCompraItem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    // Exitem um item lanche com o mesmo ID e um carrinho Compra com o mesmo ID?
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            // Se o item não existe, o item vai ser igual a null
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }


        //Metodo para diminuir a quantidade de item do carrinho e remoção do item
        // Utilizando metodo int
        public int RemoverDoCarrinho(Lanche lanche)
        {
            // Verifica se o lanche existe no carrinho
            var carrinhoCompraItem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    // Exitem um item lanche com o mesmo ID e um carrinho Compra com o mesmo ID?
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            // Se carrinhoCompraItem existir, ou seja diferente de null
            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }

            _context.SaveChanges();
            return quantidadeLocal;
        }

        /*          
         => Metodo para diminuir a quantidade de item do carrinho e remoção do item
            Utilizando metodo void:
                Neste metodo, não precisa declarar a variavel quantidadeLocal e não precisa fazer o retorno.
                    (Desse jeito fica mais facial a compreensao)

        public void RemoverDoCarrinho(Lanche lanche)
        {
            // Verifica se o lanche existe no carrinho
            var carrinhoCompraItem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    // Exitem um item lanche com o mesmo ID e um carrinho Compra com o mesmo ID?
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);           

            // Se carrinhoCompraItem existir, ou seja diferente de null
            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                   
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();           
        } 
        */

        // Metodo para retorna a lista de lanche do carrinho
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                    _context.CarrinhoCompraItens
                    .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                    .Include(s => s.Lanche)
                    .ToList());
        }

        //Metodo para limpar o carrinho
        public void LimparCarrinho()
        {
            // Seleciona os itens do carrinho utilizando o ID e colocar essa selação em uma variavel
            var carrinhoItens = _context.CarrinhoCompraItens
                                .Where(carrinho =>
                                carrinho.CarrinhoCompraId == CarrinhoCompraId);

            // Remove item selecionado e salva a alteração
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        //Metodo para exibir o total do carrinho
        public decimal GetCarrinhoCompraTotal()
        {
            //Seleciona o carrinho pelo ID e calcula o o total 
            var total = _context.CarrinhoCompraItens
                        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(c => c.Lanche.Preco * c.Quantidade).Sum(); 
            return total;
        }

    }

}
