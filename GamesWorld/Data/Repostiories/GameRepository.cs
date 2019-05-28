using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Repostiories
{
    public class GameRepository: IGameRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Game> Games => _appDbContext.Games;
    }
}
