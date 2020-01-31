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
                ChessFigure chessFigure = input.ChessFigures.FirstOrDefault(m => m.itemId == input.CurrentItemId);
                if (chessFigure != null)
                {
                    FigureIndex figureIndex = chessFigure.Properties;
                    PlayChess playChess = new PlayChess(_context, input);
                    chessGameOutput.PossibleIndexes = playChess.GetPossibleIndexesInChessTable();
                    JsonResult jsonResult = new JsonResult(chessGameOutput);
                    return jsonResult;
                }
                return null;
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