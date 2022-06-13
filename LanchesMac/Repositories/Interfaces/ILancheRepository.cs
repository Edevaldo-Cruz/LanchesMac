using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        // Retorna todos os lanches
        IEnumerable<Lanche> Lanches { get; }

        //Retorna todos os lanches definidos como preferidos
        IEnumerable<Lanche> LanchesPreferidos { get; }

        // Retorna lanches pelo Id
        Lanche GetLanchesById(int lancheId);
    }
}
