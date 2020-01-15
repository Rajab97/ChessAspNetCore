using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChessWebAspNetCore.Helpers;
using Microsoft.EntityFrameworkCore;
using ChessWebAspNetCore.Models;
using Newtonsoft.Json;

namespace ChessWebAspNetCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessGameController : ControllerBase
    {
        private readonly ChessGameContext _context;
        [HttpPost]
        public JsonResult Post([FromBody] ChessGameInput input) {

            try
            {
                ChessGameOutput chessGameOutput = new ChessGameOutput();
                FigureIndex figureIndex = input.ChessFigures.FirstOrDefault(m => m.Id == input.CurrentFigureId).Properties;
                PlayChess playChess = new PlayChess(_context, input.CurrentFigureId, figureIndex);
                chessGameOutput.PossibleIndexes = playChess.GetPossibleIndexesInChessTable();
                JsonResult jsonResult = new JsonResult(chessGameOutput);
                return jsonResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ChessGameController(ChessGameContext context)
        {
            _context = context;
        }
    }

}