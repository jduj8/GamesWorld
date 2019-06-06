using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesWorld.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;
        
        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _cart.GetItemsInCart();
            _cart.CartItems = items;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some games!");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CompletedOrder = "Thanks for your order!";
            return View();
        }
    }
}
