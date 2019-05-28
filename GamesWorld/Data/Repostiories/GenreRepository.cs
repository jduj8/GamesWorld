using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Repostiories
{
    public class GenreRepository: IGenreRepository
    {
        private readonly AppDbContext _appDbContext;

        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Genre> Genres => _appDbContext.Genres;
    }
}
