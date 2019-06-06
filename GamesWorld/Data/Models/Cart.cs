using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{

    public class Cart
    {
        private readonly AppDbContext _appDbContext;

        private Cart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CartID { get; set; }

        public List<CartItem> CartItems  { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //getRequiredService get access to our session
            //GetService() returns null if a service does not exist, GetRequiredService() throws an exception instead

            var context = services.GetService<AppDbContext>();

            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartID);
            Debug.WriteLine(cartID);
            return new Cart(context) { CartID = cartID };
        }

        public void AddToCart(Product product, int amount)
        {
            var cartItem =
                _appDbContext.CartItems.SingleOrDefault(
                    s => s.Product.ProductID == product.ProductID &&
                    s.CartID == CartID);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartID = CartID,
                    Product = product,
                    Amount = 1
                };

                Debug.WriteLine(cartItem.Product.Price);
                Debug.WriteLine(_appDbContext.CartItems.Count());

                _appDbContext.CartItems.Add(cartItem);

                
            }

            else
            {
                cartItem.Amount++;
            }

            _appDbContext.SaveChanges();
            Debug.WriteLine(_appDbContext.CartItems.Count());
        }

        public int RemoveFromCart(Product product)
        {
            var cartItem = _appDbContext.CartItems.SingleOrDefault(
                s => s.Product.ProductID == product.ProductID &&
                s.CartID == CartID);

            var currentAmount = 0;

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    currentAmount = cartItem.Amount;
                }

                else
                {
                    _appDbContext.CartItems.Remove(cartItem);
                }
            }

            _appDbContext.SaveChanges();

            return currentAmount;
        }

        public List<CartItem> GetItemsInCart()
        {
            Debug.WriteLine("Get items");
            Debug.WriteLine(_appDbContext.CartItems.Count());
            Debug.WriteLine(CartID);
            return CartItems ?? (
                    CartItems = _appDbContext.CartItems.Where(
                        c => c.CartID == CartID).
                        Include(s => s.Product).Include(g => g.Product.Game).
                        ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .CartItems
                .Where(cart => cart.CartID == CartID);

            _appDbContext.CartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetTotalCartPrice()
        {
            var total = _appDbContext.CartItems.Where(c =>
                c.CartID == CartID).Select(
                c => c.Product.Price * c.Amount).Sum();

            return total;
        }

    }
}
