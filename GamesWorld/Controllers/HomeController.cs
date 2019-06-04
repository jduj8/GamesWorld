using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesWorld.Models;
using GamesWorld.Data.Interfaces;
using GamesWorld.ViewModels;

namespace GamesWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                SomeGames = _productRepository.Products.OrderByDescending(p => p.ProductID).Take(3).ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
