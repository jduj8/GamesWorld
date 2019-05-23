using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; set; }

        Product GetProductByID(int productID);
    }
}
