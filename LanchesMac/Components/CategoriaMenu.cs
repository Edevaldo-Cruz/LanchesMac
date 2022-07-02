using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        // Indico qual tipo é minha variavel
        private readonly ICategoriaRepository _CategoriaRepository;

        // Preencho minha varial com as informações
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _CategoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _CategoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);
        }
    }
}
