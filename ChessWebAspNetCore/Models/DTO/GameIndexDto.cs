using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Models.DTO
{
    public class GameIndexDto
    {
        public IEnumerable<Figures> Figures { get; set; }
        public IEnumerable<FigureToIndex> FigureToIndixes { get; set; }
    }
}
