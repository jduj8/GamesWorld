using GamesWorld.Data.Models;
using GamesWorld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Components
{
    /*
    View components are similar to partial views, but they're much more powerful. 
    View components don't use model binding, and only depend on the data provided when calling into it. 
    This article was written using controllers and views, but view components also work with Razor Pages. 
    */

    public class CartSummary: ViewComponent
    {
        private readonly Cart _cart;

        public CartSummary(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetItemsInCart();

            _cart.CartItems = items;

            var cartViewModel = new CartViewModel()
            {
                Cart = _cart,
                TotalCartCost = _cart.GetTotalCartPrice()
            };

            return View(cartViewModel);
        }
    }
}
