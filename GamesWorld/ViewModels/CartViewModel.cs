using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }

        public decimal TotalCartCost { get; set; }
    }
}
