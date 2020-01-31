using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChessWebAspNetCore.Models;
using ChessWebAspNetCore.Helpers;

namespace ChessWebAspNetCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckStateOfFigureController : ControllerBase
    {
        private readonly ChessGameContext _context;

        [HttpPost]
        public JsonResult Post([FromBody] ChessGameInput input)
        {
            if (input.ChessFigures == null || input.ChessFigures.Length == 0)
            {
                return new JsonResult(new { Result = false });
            }
            PlayChess playChess = new PlayChess(_context, input);
            List<FigureIndex> suitableIndexes = playChess.GetPossibleIndexesInChessTable();
            FigureIndex findedIndex = suitableIndexes.FirstOrDefault(m => m.Col == input.NewTableIndexForFigure.Col && m.Row == input.NewTableIndexForFigure.Row);
            if (findedIndex.Row == null || findedIndex.Col == null)
            {
                return new JsonResult(new { Result = false });
            }
            return new JsonResult(new { Result = true });
        }
        public CheckStateOfFigureController(ChessGameContext chessGameContext)
        {
            _context = chessGameContext;
        }
    }
}