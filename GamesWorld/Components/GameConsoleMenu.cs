using GamesWorld.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesWorld.Components
{
    public class GameConsoleMenu : ViewComponent
    {
        private readonly IGameConsoleRepository _gameConsoleRepository;

        public GameConsoleMenu(IGameConsoleRepository gameConsoleRepository)
        {
            _gameConsoleRepository = gameConsoleRepository;
        }

        public IViewComponentResult Invoke()
        {
            var gameConsoles = _gameConsoleRepository.GameConsoles.OrderBy(c => c.GameConsoleName);
            return View(gameConsoles);
        }
    }
}
