using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class Console
    {
        public int ConsoleID { get; set; }

        public string ConsoleName { get; set; }

        public string Description { get; set; }

        public List<Game> Games { get; set; }

    }
}
