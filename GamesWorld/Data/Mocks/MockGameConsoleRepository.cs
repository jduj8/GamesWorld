using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Mocks
{
    public class MockGameConsoleRepository : IGameConsoleRepository
    {
        public IEnumerable<GameConsole> GameConsoles
        {
            get
            {
                return new List<GameConsole>
                {
                    new GameConsole { GameConsoleName = "PC", Description = "PC games"},
                    new GameConsole { GameConsoleName = "PS4", Description = "PS4 games"},
                    new GameConsole { GameConsoleName = "XBOX", Description = "XBOX games"},
                    new GameConsole { GameConsoleName = "Nintendo", Description = "Nintendo games"}
                };
            }
            set => throw new NotImplementedException();
        }
    }
}
