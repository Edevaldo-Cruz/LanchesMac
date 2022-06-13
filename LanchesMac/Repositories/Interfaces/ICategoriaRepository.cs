using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        /*
            Defini um contrato de interface:
                IEnumerable gera uma coleção de objetos
                Categoria fornece as informações    
                Categorias é o retorno da informações.
         */
        IEnumerable<Categoria> Categorias { get; }

    }
}
