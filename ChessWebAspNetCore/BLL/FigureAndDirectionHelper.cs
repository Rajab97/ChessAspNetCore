using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Models;
namespace ChessWebAspNetCore.BLL
{
    public static class FigureAndDirectionHelper
    {
        public static IEnumerable<Directions> GetDirectionWhichNotAvailableForFigure(int figureId, ChessGameContext chessGameContext)
        {
            foreach (Directions item in chessGameContext.Directions)
            {
                if (!chessGameContext.FigureToDirections.Any(m => m.DirectionId == item.Id && m.FigureId == figureId))
                {
                    yield return item;
                }
            }
        }
    }
}
