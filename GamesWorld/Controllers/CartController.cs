using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using GamesWorld.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesWorld.Controllers
{
    public class CartController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly Cart _cart;

        public CartController(IProductRepository productRepository, Cart cart)
        {
            _productRepository = productRepository;
            _cart = cart;
        }

        public ViewResult Index()
        {
            var items = _cart.GetItemsInCart();
            _cart.CartItems = items;
            ViewBag.Product = items.Count;

            var cartViewModel = new CartViewModel()
            {
                Cart = _cart,
                TotalCartCost = _cart.GetTotalCartPrice()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int productID)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            Debug.WriteLine("AAAAAsdaaaaaaaaaaaaaaaaaaaaaaaa", selectedProduct.Game.Name);
            if (selectedProduct != null)
            {
                _cart.AddToCart(selectedProduct, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int productID)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductID == productID);

            if (selectedProduct != null)
            {
                _cart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        
    }
}
