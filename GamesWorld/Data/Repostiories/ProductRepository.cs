using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Repostiories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products => _appDbContext.Products.Include(g => g.Game);
        

        public Product GetProductByID(int productID)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductID == productID);
        }
    }
}
