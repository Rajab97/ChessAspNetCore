using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Models;
namespace ChessWebAspNetCore.BLL
{
    public static class DirectionAndDescriptionHelper
    {
        public static IEnumerable<DirectionDescription> GetDescriptionsWhichNotAvailableForCurrentDirection(int directionId, ChessGameContext chessGameContext)
        {
            foreach (DirectionDescription item in chessGameContext.DirectionDescription)
            {
                if (!chessGameContext.DirectionToDescription.Any(m => m.DescriptionId == item.Id && m.DirectionId == directionId))
                {
                    yield return item;
                }
            }
        }
    }
}
