using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class GameConsole
    {
        public int GameConsoleID { get; set; }

        public string GameConsoleName { get; set; }

        public string Description { get; set; }

        public List<Game> Games
        {
            get; set;
        }
    }
}
