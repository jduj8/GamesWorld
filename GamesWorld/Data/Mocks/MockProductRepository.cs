using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private readonly IGameRepository _repositoryGame = new MockGameRepository();
        private readonly IGameConsoleRepository _gameConsoleRepository = new MockGameConsoleRepository();


        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Game = _repositoryGame.Games.ElementAt(1),
                        GameConsole = _gameConsoleRepository.GameConsoles.First(),
                        Price = 19.9M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6259/6259297_sd.jpg;maxHeight=640;maxWidth=550"
                    },

                    new Product
                    {
                        Game = _repositoryGame.Games.First(),
                        GameConsole = _gameConsoleRepository.GameConsoles.First(),
                        Price = 31.3M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6259/6259445_sd.jpg;maxHeight=640;maxWidth=550",
                    },

                    new Product
                    {
                        Game = _repositoryGame.Games.First(),
                        GameConsole = _gameConsoleRepository.GameConsoles.First(),
                        Price = 21.4M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6255/6255133_sd.jpg;maxHeight=640;maxWidth=550"
                    },

                    new Product
                    {
                        Game = _repositoryGame.Games.ElementAt(2),
                        GameConsole = _gameConsoleRepository.GameConsoles.First(),
                        Price = 50.60M,
                        InStock = true,
                        ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5887/5887114_sd.jpg;maxHeight=640;maxWidth=550"

                    }
                };
            }
                        
            
            set => throw new NotImplementedException();
        }

        public Product GetProductByID(int productID)
        {
            return Products.FirstOrDefault(p => p.ProductID == productID);
        }
    }
}
