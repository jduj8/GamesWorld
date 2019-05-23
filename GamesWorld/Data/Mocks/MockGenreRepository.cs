using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Mocks
{
    public class MockGenreRepository : IGenreRepository
    {
        public IEnumerable<Genre> Genres {
            get
            {
                return new List<Genre>
                {
                    new Genre { GenreName = "Action", Description = "Action games"},
                    new Genre { GenreName = "Sport", Description = "Sport games"},
                    new Genre { GenreName = "Racing", Description = "Racing games"},
                    new Genre { GenreName = "Avanture", Description = "Avanture games"}
                };
            }

            set => throw new NotImplementedException();
        }
    }
}
