using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers
{
    public class ChessFigure
    {

        public int Id { get; set; }
        public int itemId { get; set; }
        public bool WhiteOrBlack { get; set; }
        public FigureIndex Properties { get; set; }

       
    }
}
