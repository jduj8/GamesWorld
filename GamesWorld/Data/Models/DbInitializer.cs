using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            /*AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();*/

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(Genres.Select(gen => gen.Value));
            }

            if (!context.Games.Any())
            {
                context.Games.AddRange(Games.Select(gam => gam.Value));
            }

            if (!context.GameConsoles.Any())
            {
                context.GameConsoles.AddRange(GameConsole.Select(gc => gc.Value));
            }


            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Game = Games["GTA V"],
                        GameConsole = GameConsole["PC"],
                        Price = 19.9M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6259/6259297_sd.jpg;maxHeight=640;maxWidth=550"
                    },

                    new Product
                    {
                        Game = Games["FIFA 19"],
                        GameConsole = GameConsole["PS4"],
                        Price = 31.3M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6259/6259445_sd.jpg;maxHeight=640;maxWidth=550",
                    },

                    new Product
                    {
                        Game = Games["Hitman 2"],
                        GameConsole = GameConsole["PC"],
                        Price = 21.4M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6255/6255133_sd.jpg;maxHeight=640;maxWidth=550"
                    },

                    new Product
                    {
                        Game = Games["Tekken 7"],
                        GameConsole = GameConsole["XBOX"],
                        Price = 50.60M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5887/5887114_sd.jpg;maxHeight=640;maxWidth=550"

                    }
                );
            }

            
            context.SaveChanges();
        }

        private static Dictionary<string, GameConsole> gameconsole;
        public static Dictionary<string, GameConsole> GameConsole
        {
            get
            {
                if (gameconsole == null)
                {
                    var consolesList = new GameConsole[]
                    {
                        new GameConsole { GameConsoleName = "PC", Description = "PC games"},
                        new GameConsole { GameConsoleName = "PS4", Description = "PS4 games"},
                        new GameConsole { GameConsoleName = "XBOX", Description = "XBOX games"},
                        new GameConsole { GameConsoleName = "Nintendo", Description = "Nintendo games"}
                    };

                    gameconsole = new Dictionary<string, GameConsole>();

                    foreach (GameConsole console in consolesList)
                    {
                        gameconsole.Add(console.GameConsoleName, console);
                    }
                }

                return gameconsole;
            }
        }

        private static Dictionary<string, Genre> genres;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    var genresList = new Genre[]
                    {
                        new Genre { GenreName = "Action", Description = "Action games"},
                        new Genre { GenreName = "Sport", Description = "Sport games"},
                        new Genre { GenreName = "Racing", Description = "Racing games"},
                        new Genre { GenreName = "Avanture", Description = "Avanture games"}
                    };

                    genres = new Dictionary<string, Genre>();

                    foreach (Genre genre in genresList)
                    {
                        genres.Add(genre.GenreName, genre);
                    }
                }

                return genres;
            }
        }

        private static Dictionary<string, Game> games;
        public static Dictionary<string, Game> Games
        {
            get
            {
                if (games == null)
                {
                    var gamesList = new Game[]
                    {
                        new Game
                        {
                            Name = "GTA V",
                            Description = "The Grand Theft Auto V: Premium Online Edition is available for PS4 and includes the complete Grand Theft Auto V story experience, the ever - evolving world of Grand Theft Auto Online, and all the existing gameplay upgrades and content, including The Doomsday Heist, Gunrunning, Smuggler's Run, Bikers and much more. You'll also get the Criminal Enterprise starter pack.",
                            Genre = Genres["Action"]
                        },

                        new Game
                        {
                            Name = "FIFA 19",
                            Description = "Kick off your legend in FIFA 19 for PlayStation 4.The immersive game lets you build the ultimate squad from characters you create or handpicked from some of the best players to ever grace the field.The new active touch and 50 / 50 battles systems let you demonstrate your skill and dominate the field in FIFA 19.",
                            Genre = Genres["Sport"]
                        },

                        new Game
                        {
                            Name = "Hitman 2",
                            Description = "Make the world your weapon. Become Agent 47, and dismantle the elusive Shadow Client's militia. Think deadly as you travel the globe to take down your targets in six new sandbox environments, improvise each assassination, and explore the franchise's advanced installment.",
                            Genre = Genres["Action"]
                        },

                        new Game
                        {
                            Name = "Tekken 7",
                            Description = "Choose character and fight",
                            Genre = Genres["Sport"]
                        }
                    };

                    games = new Dictionary<string, Game>();

                    foreach (Game game in gamesList)
                    {
                        games.Add(game.Name, game);
                    }
                }

                return games;
            }
        }

    }
}
