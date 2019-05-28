using GamesWorld.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameConsole> GameConsoles { get; set; }

        public DbSet<Product> Products { get; set; }


    }
}
