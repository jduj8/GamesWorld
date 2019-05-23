using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data.Interfaces;
using GamesWorld.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesWorld.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGameConsoleRepository _gameConsoleRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGenreRepository _genreRepository;

        public ProductController(IGameConsoleRepository gameConsoleRepository, IGameRepository gameRepository, IProductRepository productRepository, IGenreRepository genreRepository)
        {
            _gameConsoleRepository = gameConsoleRepository;
            _gameRepository = gameRepository;
            _productRepository = productRepository;
            _genreRepository = genreRepository;
        }

        public ViewResult List()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();

            productListViewModel.Products = _productRepository.Products;
            productListViewModel.CurrentGameConsole = "PS4";

            return View(productListViewModel);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
