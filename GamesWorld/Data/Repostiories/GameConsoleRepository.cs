using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Repostiories
{
    public class GameConsoleRepository : IGameConsoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameConsoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<GameConsole> GameConsoles => _appDbContext.GameConsoles;
    }
}
