using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers
{
    public struct FigureIndex
    {
        public int? Row { get; set; }
        public int? Col { get; set; }

        public static FigureIndex CreateInstance(int? Row,int? Col)
        {
            FigureIndex figureIndex = new FigureIndex()
            {
                Col = Col,
                Row = Row
            };
            return figureIndex;
        }
    }
}
