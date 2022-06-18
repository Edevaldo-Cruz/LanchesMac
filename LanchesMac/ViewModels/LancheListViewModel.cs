using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class LancheListViewModel
    {
        //Propiedade para exibir uma lista.
        public IEnumerable<Lanche> Lanches { get; set; }

         
        public string CategoriaAtual { get; set; }
    }
}
