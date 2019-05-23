using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int GameID { get; set; }

        public int GameConsoleID { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }

        public string ImageUrl { get; set; }

        public virtual Game Game { get; set; }

        public virtual GameConsole GameConsole { get; set; }

        

    }
}
