using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers
{
    public class ChessGameInput
    {
        public int CurrentFigureId { get; set; }
        public ChessFigure[] ChessFigures { get; set; }
    }
}
