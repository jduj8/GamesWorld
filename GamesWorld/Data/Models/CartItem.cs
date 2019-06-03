using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public string CartID { get; set; }
    }
}
