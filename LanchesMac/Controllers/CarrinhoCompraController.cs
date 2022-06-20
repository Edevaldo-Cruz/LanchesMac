﻿using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };

            return View(carrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinho(int lancheId)
        {
            var lancheSeleCionado = _lancheRepository.Lanches
                                    .FirstOrDefault(p=> p.LancheId == lancheId);

            if (lancheSeleCionado != null)
            {
                _carrinhoCompra.AdionarAoCarrinho(lancheSeleCionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinho(int lancheId)
        {
            var lancheSeleCionado = _lancheRepository.Lanches
                                    .FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSeleCionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSeleCionado);
            }
            return RedirectToAction("Index");
        }

    }
}
