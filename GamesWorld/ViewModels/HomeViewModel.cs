﻿using GamesWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> SomeGames { get; set; }
    }
}
