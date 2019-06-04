using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
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

        public ViewResult List(string console)
        {
            string _console = console;
            IEnumerable<Product> products;

            string currentConsole = string.Empty;

            if (string.IsNullOrEmpty(console))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductID);
                currentConsole = "All console";
            }

            else
            {
                if (string.Equals("PS4", _console, StringComparison.OrdinalIgnoreCase))
                {
                    products = _productRepository.Products.Where(p => p.GameConsole.GameConsoleName.Equals("PS4")).OrderBy(p => p.ProductID);
                }

                else if (string.Equals("PC", _console, StringComparison.OrdinalIgnoreCase))
                {
                    products = _productRepository.Products.Where(p => p.GameConsole.GameConsoleName.Equals("PC")).OrderBy(p => p.ProductID);
                }

                else
                {
                    products = _productRepository.Products.Where(p => p.GameConsole.GameConsoleName.Equals("XBOX")).OrderBy(p => p.ProductID);
                }

                currentConsole = console;
            }

            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Products = products,
                CurrentGameConsole = currentConsole
            };



            return View(productListViewModel);
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
