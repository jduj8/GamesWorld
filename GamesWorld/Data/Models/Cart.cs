using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

            string cartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartID", cartID);

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

                _appDbContext.CartItems.Add(cartItem);
            }

            else
            {
                cartItem.Amount++;
            }

            _appDbContext.SaveChanges();
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
            return CartItems ?? (
                    CartItems = _appDbContext.CartItems.Where(
                        c => c.CartID == CartID).
                        Include(s => s.Product).
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
