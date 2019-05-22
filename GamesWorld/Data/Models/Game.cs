using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class Game
    {
        public int GameID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int LeftOver { get; set; }

        public int ConsoleID { get; set; }

        public int GenreID { get; set; }

        public virtual Console Console { get; set; }

        public virtual Genre Genre { get; set; }


    }
}
