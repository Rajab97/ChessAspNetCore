using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Models;
using ChessWebAspNetCore.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            gameIndexDto.FigureToIndixes = _context.FigureToIndex.Include(m => m.Figure).Include(m => m.Index);
            List<FigureToIndex> aw = gameIndexDto.FigureToIndixes.ToList();
             return View(gameIndexDto);
        }
    }
}