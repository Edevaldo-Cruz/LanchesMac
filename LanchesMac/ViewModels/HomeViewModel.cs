using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class HomeViewModel
    {
        // IEnumerable retorna uma lista
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
