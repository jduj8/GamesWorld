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

        

    }
}
