using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;

namespace GamesWorld.Data.Mocks
{
    public class MockGameRepository : IGameRepository
    {
        
        private readonly IGenreRepository _genreRepository = new MockGenreRepository();
        public IEnumerable<Game> Games
        {
            get
            {
                return new List<Game>
                {
                    new Game
                    {
                        Name = "GTA V",
                        Description = "The Grand Theft Auto V: Premium Online Edition is available for PS4 and includes the complete Grand Theft Auto V story experience, the ever - evolving world of Grand Theft Auto Online, and all the existing gameplay upgrades and content, including The Doomsday Heist, Gunrunning, Smuggler's Run, Bikers and much more. You'll also get the Criminal Enterprise starter pack.",
                        Genre = _genreRepository.Genres.First()
                    },

                    new Game
                    {
                        Name = "FIFA 19",
                        Description = "Kick off your legend in FIFA 19 for PlayStation 4.The immersive game lets you build the ultimate squad from characters you create or handpicked from some of the best players to ever grace the field.The new active touch and 50 / 50 battles systems let you demonstrate your skill and dominate the field in FIFA 19.",
                        Genre = _genreRepository.Genres.First()
                    },

                    new Game
                    {
                        Name = "Hitman 2",
                        Description = "Make the world your weapon. Become Agent 47, and dismantle the elusive Shadow Client's militia. Think deadly as you travel the globe to take down your targets in six new sandbox environments, improvise each assassination, and explore the franchise's advanced installment.",
                        Genre = _genreRepository.Genres.First()

                    }
                };
            }

            set => throw new NotImplementedException();
        }

        public Game GetGameByID(int gameID)
        {
            throw new NotImplementedException();
        }
    }
}
