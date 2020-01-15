using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Models;
using ChessWebAspNetCore.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ChessWebAspNetCore.Controllers
{
    public class GameController : Controller
    {
        private ChessGameContext _context;
        public GameController(ChessGameContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            GameIndexDto gameIndexDto = new GameIndexDto();
            gameIndexDto.Figures = _context.Figures;


            return View(gameIndexDto);
        }
    }
}